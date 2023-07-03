<template>
    <div class="base-table">
        <table>
            <thead>
                <tr>
                    <th v-for="header in headers" :key="header" v-if="header !== 'id'">{{ header }}</th>
                    <th>Action</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="item in items" :key="item.id">
                    
                    <td v-for="(value, key) in item" :key="key" v-if="key !== 'id'">{{ value }}</td>
                    <td>
                        <button class="btn btn-edit" @click="editItem(item)">Edit</button>
                        <button class="btn btn-delete" @click="deleteItem(item.id)">Delete</button>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script>
import axios from 'axios';

export default {
    name: 'BaseTable',
    props: {
        urlGetAllData: {
            type: String,
            default: ''
        },
        urlDelete: {
            type: String,
            default: ''
        },
        urlUpdate: {
            type: String,
            default: ''
        },
    },
    data() {
        return {
            items: [],
            headers: [],
        }
    },
    methods: {
        getData() {
            axios.get(this.urlGetAllData)
                .then(response => {
                    this.items = response.data;
                    this.headers = this.items.length > 0 ? Object.keys(this.items[0]) : [];                    
                })
                .catch(error => {
                    console.log(error);
                });
        },
        editItem(item) {
            axios.put(`${this.urlUpdate}/${item.id}`, item)
                .then(() => {
                    this.getData();
                })
                .catch(error => {
                    console.log(error);
                });
        },
        deleteItem(id) {
            axios.delete(`${this.urlDelete}/${id}`)
                .then(() => {
                    this.getData();
                })
                .catch(error => {
                    console.log(error);
                });
        }
    },
    created() {
        this.getData();
    },
}
</script>


<style scoped>
.base-table {
    width: 100%;
    height: 100%; /* Thêm dòng này */
    overflow-y: auto; /* Thêm dòng này */
    margin: 0 auto;
}

.base-table table {
    width: 100%;
    border-collapse: collapse;
}

.base-table th,
.base-table td {
    padding: 15px;
    border: 1px solid #b1b0b0;
}

.base-table tr:nth-child(even) {
    background-color: #f2f2f2;
}

.base-table .btn {
    padding: 5px 10px;
    margin-right: 5px;
    border: none;
    cursor: pointer;
    transition: background-color 0.3s ease;
}

.base-table .btn-edit {
    background-color: #4caf50;
    color: white;
}

.base-table .btn-edit:hover {
    background-color: #45a049;
}

.base-table .btn-delete {
    background-color: #f44336;
    color: white;
}

.base-table .btn-delete:hover {
    background-color: #da190b;
}
</style>

