<template>
    <div>
        <RegisterActiveForm 
            :isActive="showFormActive" 
            @close="showFormActive = false" 
            :titleForm="titleFormActive"
            :listActiveLabel="listPropsLabelActive" 
            :listData="listPropsDataActive" 
            />

        <div class="lunch-card" @click="toggleLunchList(0)">
            <div class="left-part">
                <img src="https://cdn-img-v2.webbnc.net/uploadv2/web/11/11075/media/2018/12/13/10/21/1544695352_town-resturant-international-buffet_1_orig.jpg"
                    alt="avatar" class="avatar" />
                <h2 class="card-title" style="font-size: 6vh;">Dự tiệc ngoài trời</h2>
            </div>
            <button class="btn-plus" @click.stop="addItem(0)"> <i class="fas fa-plus"></i></button>
            <div class="arrow-icon" :class="{ 'arrow-up': showLunchList[0] }"></div>
        </div>
        <div class="window-show" :class="{ 'window-show-active': showLunchList[0] }">
            <BaseTable v-if="showLunchList[0]" url-get-all-data="https://localhost:7257/api/PeopleChooseProduct/groupProduct" />
        </div>

        <div class="lunch-card" @click="toggleLunchList(1)">
            <div class="left-part">
                <img src="https://www.greenyellow.vn/wp-content/uploads/2022/06/GREENYELLOW-300-scaled-e1663668599682-1024x683.jpg"
                    alt="avatar" class="avatar" />
                <h2 class="card-title" style="font-size: 6vh;">Hoạt động TeamBuilding</h2>
            </div>
            <button class="btn-plus" @click.stop="addItem(1)"> <i class="fas fa-plus"></i></button>
            <div class="arrow-icon" :class="{ 'arrow-up': showLunchList[1] }"></div>
        </div>
        <div class="window-show" :class="{ 'window-show-active': showLunchList[1] }">
            <BaseTable v-if="showLunchList[1]" url-get-all-data="https://localhost:7257/api/DaiBieu" />
        </div>
    </div>
</template>
  
<script>
import BaseTable from '../components/BaseTable.vue';
import RegisterActiveForm from '../components/RegisterActiveForm.vue';

export default {
    components: {
        BaseTable,
        RegisterActiveForm,
    },
    data() {
        return {
            showLunchList: [false, false], // Trạng thái hiển thị danh sách card
            showFormActive: false, // Kiểm soát hiển thị form active
            titleFormActive: '', // Tiêu đề của form active
            listPropsLabelActive: [],
            listPropsDataActive:[],
            listLabel: [
                ['Đồ ăn', 'Thức uống','Thuốc lá'],
                ['Game cá nhân','Game đồng đội']
            ], // Danh sách labels
            listData: [
                {
                'Đồ ăn': ['Món ăn 1', 'Món ăn 2', 'Món ăn 3'], // Danh sách dữ liệu cho label 'Đồ ăn'
                'Thức uống': ['Đồ uống 1', 'Đồ uống 2', 'Đồ uống 3','Đồ uống 4', 'Đồ uống 5', 'Đồ uống 6', 'Đồ uống 7'  ], // Danh sách dữ liệu cho label 'Thức uống'
                'Thuốc lá': ['Thăng Long','Vinataba','Hoàn Kiếm' ],
            },
            {
                'Game cá nhân': ['Cờ vua', 'Cờ tướng', 'Cờ caro'],
                'Game đồng đội': ['Nhảy bao bố','Kéo co','Kềnh cang'],
            }
        ]
        };
    },
    methods: {
        toggleLunchList(i) {
            this.showLunchList[i] = !this.showLunchList[i];
        },
        addItem(i) {
            this.showFormActive = true;
            this.titleFormActive = i === 0 ? 'Dự tiệc ngoài trời' : 'Hoạt động TeamBuilding';
            this.listPropsLabelActive = this.listLabel[i];
            this.listPropsDataActive = this.listData[i];
        },
    },
};
</script>
  

<style scoped>
.lunch-card {
    display: flex;
    align-items: center;
    justify-content: space-between;
    padding: 10px;
    background-color: #FFFFFF;
    cursor: pointer;
    position: relative;
    border: 1px solid #000;
    border-radius: 15px;
    margin-bottom: 1vh;
}

.left-part {
    display: flex;
    align-items: center;
}

.card-title {
    font-size: 20px;
    font-weight: bold;
    margin-left: 10px;
}

.avatar {
    width: 20vh;
    height: 15vh;
    border-radius: 20px;
    border: 2px solid #000;
    object-fit: cover;
}

.btn-plus {
    background: none;
    border: none;
    cursor: pointer;
    padding: 5px;
    margin-left: auto;
    font-size: 6vh;
    position: absolute;
    right: 10px;
    top: 50%;
    transform: translateY(-50%);
}

.arrow-icon {
    width: 0;
    height: 0;
    border-style: solid;
    border-width: 6px 4px 0 4px;
    border-color: #888 transparent transparent;
    transition: transform 0.3s ease;
}

.arrow-up {
    transform: rotate(180deg);
}

.window-show {
    max-height: 0;
    transition: max-height 0.5s ease-out, transform 0.5s ease-out;
    overflow: hidden;
    transform: translateY(-100%);
}

.window-show-active {
    max-height: 61vh;
    overflow-y: auto;
    transform: translateY(0);
}

</style>

