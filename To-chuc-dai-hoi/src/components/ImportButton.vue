<template>
    <div>
        <input type="file" ref="fileInput" @change="handleFileUpload" style="display: none" />
        <button type="button" class="btn btn-primary" @click="triggerFileUpload">
            <i class="import-icon fas fa-file-import"></i>
            <span>Nhập file</span>
        </button>
    </div>
</template>

<script>
import * as XLSX from 'xlsx';
import axios from 'axios';
export default {
    name: "ImportButton",
    data() {
        return {
            fileInput: null,
            fileTypes: ['txt', 'csv', 'xlsx', 'json']
        };
    },
    props: ['listMembers'],

    mounted() {
        this.fileInput = this.$refs.fileInput;
    },
    methods: {
        triggerFileUpload() {
            this.fileInput.click();
        },
        handleFileUpload(event) {
            const file = event.target.files[0];
            const fileType = file.name.split('.').pop().toLowerCase();
            if (!this.fileTypes.includes(fileType)) {
                window.alert('Loại file không hợp lệ. Vui lòng thử lại.');
                return;
            }
            if (fileType === 'txt' || fileType === 'csv') {
                this.importTextOrCsvFile(file);
            } else if (fileType === 'xlsx') {
                this.importExcelFile(file);
            }else if (fileType === 'json') {
                this.importJsonFile(file);
            }
        },

        detectDelimiter(str, appearCount) {
            const delimiters = [",", ";", ":", "|", "/", "\\", ".", "&", "?", "!", "$", "/", "*", "&", "%", "#", "@", "^", "-", "+", "=", "_", "~"];

            // Tạo một bản sao của chuỗi, loại bỏ tất cả các khoảng trắng
            const strCopy = str.replace(/\s+/g, '');

            // Đối tượng đếm số lần xuất hiện của mỗi dấu
            const delimiterCounts = {};

            // Dấu xuất hiện nhiều nhất
            let mostFrequentDelimiter = null;
            // Số lần xuất hiện nhiều nhất
            let maxCount = 0;

            // Kiểm tra từng dấu trong mảng delimiters
            for (let i = 0; i < delimiters.length; i++) {
                const delimiter = delimiters[i];

                // Đếm số lần xuất hiện của dấu trong chuỗi đã loại bỏ khoảng trắng
                const count = (strCopy.match(new RegExp("\\" + delimiter, "g")) || []).length;

                // Lưu trữ số lần xuất hiện của dấu trong đối tượng delimiterCounts
                delimiterCounts[delimiter] = count;

                // Kiểm tra xem dấu có xuất hiện nhiều hơn dấu hiện tại không
                if (count > maxCount) {
                    maxCount = count;
                    mostFrequentDelimiter = delimiter;
                }
            }

            // Kiểm tra xem có dấu nào xuất hiện với số lần bằng với appearCount hay không
            for (const delimiter in delimiterCounts) {
                if (delimiterCounts[delimiter] === appearCount) {
                    return delimiter;
                }
            }

            // Trả về dấu xuất hiện nhiều nhất (hoặc null nếu không phát hiện)
            return mostFrequentDelimiter;
        },

        checkStatus(inputString) {
            if (inputString.includes("Không")) {
                return "times";
            } else if (inputString.includes("Xét") || inputString.includes("Nghĩ") || inputString.includes("Xem") || inputString.includes("Xem")) {
                return "lightbulb";
            } else {
                return "check";
            }
        },

        async addMiltipleAsync(inputList) {
            var result = this.removeDuplicatesFromList(inputList, this.listMembers)
            try {
                if (result.length > 0) {
                    await axios.post('https://localhost:7257/api/DaiBieu/AddMultiple', result);
                    console.log("Đã thêm các đại biểu mới thành công!");
                    this.$emit('reload-data');
                } else {
                    console.log("Các đại biểu đã tồn tại!");
                }

            } catch (error) {
                console.log(`Lỗi khi gọi API: ${error.message}`);
            }
        },

        isDuplicateMember(member, listMembers) {
            return listMembers.some(existingMember =>
                existingMember.name === member.name &&
                existingMember.age === member.age &&
                existingMember.position === member.position &&
                existingMember.workPlace === member.workPlace &&
                existingMember.contact === member.contact &&
                existingMember.status === member.status
            );
        },
        removeDuplicatesFromList(inputList, listMembers) {
            return inputList.filter(member => !this.isDuplicateMember(member, listMembers));
        },
        async importTextOrCsvFile(file) {
            const reader = new FileReader();

            reader.onload = async (event) => {
                const lines = event.target.result.split('\n');
                while (lines[lines.length - 1] === '') {
                    lines.pop();
                }
                const jsonStr = JSON.stringify(lines);
                let result = [];
                if (lines.length > 0) {
                    const char = this.detectDelimiter(event.target.result, 5);
                    if (char != null) {
                        result = lines.map(line => {
                            const items = line.split(char);
                            return {
                                "id": "none",
                                "name": items[0].trim(),
                                "age": items[1].trim(),
                                "position": items[2].trim(),
                                "workPlace": items[3].trim(),
                                "contact": items[4].trim(),
                                "status": this.checkStatus(items[5].trim())
                            }
                        })
                        this.addMiltipleAsync(result);
                    }
                }
            };
            reader.readAsText(file);
        },

        importExcelFile(file) {
            const reader = new FileReader();
            reader.onload = (event) => {
                const data = new Uint8Array(event.target.result);
                const workbook = XLSX.read(data, { type: 'array' });
                const worksheet = workbook.Sheets[workbook.SheetNames[0]];
                const jsonData = XLSX.utils.sheet_to_json(worksheet);
                var result = jsonData.map(line => {
                    line.id = "none"
                    line.age = line.age.toString()
                    line.status = this.checkStatus(line.status)
                    return line;
                });
                this.addMiltipleAsync(result)
            };
            reader.readAsArrayBuffer(file);
        },
        importJsonFile(file) {
            const reader = new FileReader();
            reader.onload = (event) => {
                const data = JSON.parse(event.target.result);
                var result = data.map(line => {
                    line.id = "none"
                    line.age = line.age.toString()
                    line.status = this.checkStatus(line.status)
                    return line;
                });
                this.addMiltipleAsync(result)
            };
            reader.readAsText(file);
        },
    }
};
</script>

<style scoped>
.import-icon {
    margin-right: 0.5em;
}
</style>
