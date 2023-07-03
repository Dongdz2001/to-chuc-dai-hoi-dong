<template>
    <div class="dropdown-container">
        <button type="button" class="btn btn-primary dropdown-toggle" @click="toggleDropdown">
            <i class="export-icon fas fa-file-export"></i>
            <span>Xuất file</span>
        </button>
        <ul :class="{ 'show': isDropdownOpen }" class="dropdown-menu">
            <li v-for="option in options" :key="option.value">
                <a class="dropdown-item" :href="option.value" @click.prevent="exportData(option.value)">{{ option.label
                }}</a>
            </li>
        </ul>
    </div>
</template>
  
<script>
import { saveAs } from 'file-saver';
import * as XLSX from 'xlsx';
import jsPDF from 'jspdf';
import autoTable from 'jspdf-autotable';



export default {
    props: {
        listArray: {
            type: Array,
            required: true
        }
    },
    data() {
        return {
            listItem: [],
            isDropdownOpen: false,
            options: [
                { label: 'Text', value: 'Text' },
                { label: 'Json', value: 'json' },
                { label: 'Excel', value: 'excel' },
                { label: 'PDF', value: 'pdf' },
                { label: 'Other', value: 'other' }
            ],
            otherFileTypes: ['CSV', 'TXT', 'XML'] // Thêm các kiểu file khác nếu bạn muốn
        };
    },
    methods: {
        convertStatusFeild() {
            this.listItem = JSON.parse(JSON.stringify(this.listArray));
            for (let i = 0; i < this.listItem.length; i++) {
                delete this.listItem[i].id;
                if (this.listItem[i].status === 'check') {
                    this.listItem[i].status = 'Tham gia';
                } else if (this.listItem[i].status === 'times') {
                    this.listItem[i].status = 'Không tham gia';
                } else if (this.listItem[i].status === 'lightbulb') {
                    this.listItem[i].status = 'Xem xét';
                }
            }
        },


        toggleDropdown() {
            this.isDropdownOpen = !this.isDropdownOpen;
        },
        exportData(value) {
            this.convertStatusFeild();
            if (value === 'Text') {
                this.exportTxt();
            } else if (value === 'excel') {
                this.exportExcel();
            } else if (value === 'pdf') {
                this.exportPdf();
            } else if (value === 'json') {
                this.exportJson();
            }else if (value === 'other') {
                this.promptOtherFileType();
            }
        },
        promptOtherFileType() {
            const fileType = window.prompt('Vui lòng nhập loại file muốn xuất:', this.otherFileTypes.join(', '));
            if (this.otherFileTypes.includes(fileType.toUpperCase())) {
                if (fileType.toUpperCase() === 'CSV') {
                    this.exportCsv();
                } else {
                    console.log(`Xuất bảng ${fileType.toUpperCase()}`);
                }
            } else {
                window.alert('Loại file không hợp lệ. Vui lòng thử lại.');
            }
        },
        exportPdf() {
            const doc = new jsPDF();

            // Thay đổi font
            doc.setFont('helvetica');

            // Tạo header cho bảng dựa vào keys của object đầu tiên trong listItem
            const headers = Object.keys(this.listItem[0]);

            // Chuyển đổi dữ liệu từ listItem thành dạng mà autoTable có thể xử lý
            const data = this.listItem.map(item => Object.values(item));

            // Tạo bảng
            doc.autoTable({
                head: [headers],
                body: data,
                styles: { overflow: 'linebreak' },
                columnStyles: {
                    0: { cellWidth: 60 },
                    1: { cellWidth: 'auto' },
                    2: { cellWidth: 'auto' },
                    3: { cellWidth: 'auto' },
                    // Thêm các cột khác nếu cần
                },
            });

            // Lưu file
            doc.save("Danh_sach_dai_bieu.pdf");
        },

        exportExcel() {
            const worksheet = XLSX.utils.json_to_sheet(this.listItem);
            const workbook = { Sheets: { 'data': worksheet }, SheetNames: ['data'] };
            const excelBuffer = XLSX.write(workbook, { bookType: 'xlsx', type: 'array' });
            saveAs(new Blob([excelBuffer]), 'Danh_sach_dai_bieu.csv.xlsx');
        },
        exportCsv() {
            let csvContent = "data:text/csv;charset=utf-8,";
            this.listItem.forEach(item => {
                let row = Object.values(item).join(",");
                csvContent += row + "\r\n";
            });
            var encodedUri = encodeURI(csvContent);
            var link = document.createElement("a");
            link.setAttribute("href", encodedUri);
            link.setAttribute("download", "Danh_sach_dai_bieu.csv");
            link.click();
        },
        exportTxt() {
            let textContent = "";
            this.listItem.forEach(item => {
                let row = Object.values(item).join(" | ");
                textContent += row + "\n";
            });
            var blob = new Blob([textContent], { type: "text/plain;charset=utf-8" });
            saveAs(blob, "Danh_sach_dai_bieu.txt");
        },
        exportJson() {
            let jsonContent = JSON.stringify(this.listItem, null, 2);
            var blob = new Blob([jsonContent], { type: "application/json;charset=utf-8" });
            saveAs(blob, "Danh_sach_dai_bieu.json");
        }
    }
};
</script>
  
<style scoped>
.export-icon {
    margin-right: 0.5em;
}

.dropdown-container {
    position: relative;
    display: inline-block;
}

.dropdown-menu {
    display: none;
    position: absolute;
    top: 100%;
    right: 0;
    z-index: 1;
    margin-top: 0.5rem;
    min-width: 10rem;
    padding: 0.5rem 0;
    list-style: none;
    background-color: #fff;
    border: 1px solid rgba(0, 0, 0, 0.15);
    border-radius: 0.25rem;
}

.show {
    display: block;
}

.dropdown-item {
    display: block;
    padding: 0.25rem 1.5rem;
    clear: both;
    font-weight: 400;
    color: #212529;
    text-align: inherit;
    white-space: nowrap;
    background-color: transparent;
    border: 0;
}

.dropdown-item:hover,
.dropdown-item:focus {
    color: #fff;
    text-decoration: none;
    background-color: #007bff;
}
</style>
  