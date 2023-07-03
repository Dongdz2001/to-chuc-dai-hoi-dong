<template>
  <div class="modal" v-if="isActive">
    <div class="modal-background" @click="close"></div>
    <div class="modal-content">
      <div class="box">
        <h2 class="text-4xl">{{ titleForm }}</h2>
        <form @submit.prevent="register">
          <div class="field">
            <label class="label">Họ và tên</label>
            <input class="input" type="text" v-model="name" required>
          </div>
          <div class="field">
            <label class="label">Liên hệ </label>
            <input class="input" type="text" v-model="contact" required>
          </div>
          <div class="field" v-for="(item, index) in listActiveLabel" :key="index">
            <p class="label">{{ item }}</p>
            <br>
            <div class="wrap-item">
              <div v-for="(data, dataIndex) in listData[item]" :key="dataIndex">
                <div class="item-container-checkbox">
                  <input
                    style="margin: 5px"
                    type="checkbox"
                    :id="'option'+dataIndex"
                    :value="data"
                    :checked="selected[item] && selected[item].includes(data)"
                    @change="updateSelected(item, data)"
                  >
                  <label style="padding-right: 10px;" :for="'option'+dataIndex">{{ data }}</label>
                </div>
              </div>
            </div>
          </div>
          <button type="submit" class="button btn-primary">Xác nhận</button>
        </form>
      </div>
      <button class="modal-close is-large" @click="close">X</button>
    </div>
  </div>
</template>

<script>
export default {
  name: "RegisterActiveForm",
  props: ['isActive', 'titleForm', 'listActiveLabel', 'listData'],
  data() {
    return {
      name: '',
      contact: '',
      selected: {},
    }
  },
  methods: {
    close() {
      this.$emit('close');
    },
    register() {
      console.log(`Registering user ${this.name}`);
      console.log('Checkbox selections: ', this.selected);
      this.close();
    },
    updateSelected(item, data) {
      if (!this.selected[item]) {
        this.selected[item] = [];
      }
      const index = this.selected[item].indexOf(data);
      if (index > -1) {
        this.selected[item].splice(index, 1);
      } else {
        this.selected[item].push(data);
      }
    },
  },
}
</script>


    
    
<style>
.modal {
  position: fixed;
  z-index: 1000;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  display: flex;
  justify-content: center;
  align-items: center;
  background-color: rgba(0, 0, 0, 0.5);
  transition: opacity 0.3s ease, visibility 0.3s ease;
}

.modal.is-active {
  opacity: 1;
  visibility: visible;
}

.modal-content {
  position: relative;
  padding: 10px;
  background-color: aliceblue;
  border-radius: 5px;
  max-width: 100vh;
  margin-top: 100px !important;
  min-width: 40%;
  display: flex;
  flex-direction: column;
  justify-content: space-between;
  transition: opacity 0.3s ease, transform 0.3s ease;
}

.modal.is-active .modal-content {
  opacity: 1;
  transform: translateY(0);
}

.modal-close {
  position: absolute;
  top: 10px;
  right: 10px;
  background: none;
  border: none;
  font-size: 1.5em;
  cursor: pointer;
}

.modal-background {
  position: absolute;
  width: 100%;
  height: 100%;
  cursor: pointer;
}

.field {
  display: flex;
  flex-direction: row;
  justify-content: end;
  padding-bottom: 1vh;
  padding-top: 2vh;
  width: 100%;
  height: fit-content;
  margin: 0 auto;
  font-size: 18px;
  font-weight: 500;
}

.label::after {
  content: "*";
  color: red;
}
.label {
  width: max-content;
  text-align: start;
  padding-right: 20px;
  white-space: nowrap;
}


.button {
  border: 1pt solid black;
  margin-top: 5vh;
}

.input {
  padding-left: 15px;
  border-radius: 25px;
  height: 5vh;
  width: 150vh;
  width: 250px;
}


.dropdown-menu {
  display: none;
  position: absolute;
  background-color: #f1f1f1;
  min-width: 160px;
  box-shadow: 0px 8px 16px 0px rgba(0, 0, 0, 0.2);
  z-index: 1;
}

.dropdown-menu a {
  color: black;
  padding: 12px 16px;
  text-decoration: none;
  display: block;
}

.dropdown-menu a:hover {
  background-color: #ddd;
}

.show {
  display: block;
}

.wrap-item{
  margin-top: 3vh;
  display: grid;
  grid-template-columns: repeat(3, 1fr);
  width: 200vh;
  height: 100%;
  justify-content: space-around;
  padding-left: 10px;
}

.input[type="checkbox"]{
  padding-right: 10px;
}

.item-container-checkbox{
  width: 120%;
  justify-content: space-between;
}
</style>
