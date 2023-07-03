<template>
    <div class="modal" v-show="isActive">
        <div class="modal-background" @click="close"></div>
        <div class="modal-content">
            <div class="box">
                <h1 class="title">Đăng ký</h1>
                <form @submit.prevent="submitForm">
                    <div class="field">
                        <label class="label">Tên</label>
                        <input class="input" type="text" v-model="name" required>
                    </div>

                    <div class="field">
                        <label class="label">Tuổi</label>
                        <input class="input" type="number" v-model="age" required>
                    </div>

                    <div class="field">
                        <label class="label">Liên hệ</label>
                        <input class="input" type="text" v-model="contact" required>
                    </div>

                    <button type="submit" class="button is-primary">Đăng ký</button>
                </form>
            </div>
            <button class="modal-close is-large" @click="close">X</button>
        </div>
    </div>
</template>
  
<script>
export default {
    name: "FormPopup",
    props: ['isActive'],
    data() {
        return {
            name: '',
            age: '',
            contact: ''
        }
    },
    methods: {
        close() {
            this.$emit('close');
        },
        submitForm() {
            console.log(`User ${this.name} registered`);
            this.close();
        }
    }
}
</script>
  
<style scoped>
.modal {
  position: fixed;
  z-index: 1000;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background-color: rgba(0,0,0,0.5);
  display: flex;
  justify-content: center;
  align-items: center;
}

.modal-content {
  position: relative;
  background: white;
  padding: 20px;
  border-radius: 5px;
  max-width: 80%;
  min-width: 300px;
}

.modal-background, .modal-close {
  cursor: pointer;
}

.modal-close {
  position: absolute;
  top: 10px;
  right: 10px;
  background: none;
  border: none;
  font-size: 1.5em;
}
</style>
