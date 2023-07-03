<template>
  <div class="modal" v-if="isActive">
    <div class="modal-background" @click="close"></div>
    <div class="modal-content">
      <div class="box">
        <h1 class="text-4xl">Đăng ký</h1>
        <form @submit.prevent="register">
          <div class="field">
            <label class="label">Tên đăng nhập</label>
            <input class="input" type="text" v-model="username" required>
          </div>

          <div class="field">
            <label class="label">Mật khẩu</label>
            <input class="input" type="password" v-model="password" required>
          </div>

          <div class="field">
            <label class="label">Xác nhận <br> mật khẩu</label>
            <input class="input" type="password" v-model="passwordConfirm" required>
          </div>

          <div class="field">
            <label class="label">Họ và tên</label>
            <input class="input" type="text" v-model="name" required>
          </div>

          <div class="field">
            <label class="label">Liên hệ </label>
            <input class="input" type="text" v-model="contact" required>
          </div>

          <div class="field">
            <label class="label">Ngày sinh</label>
            <input class="input" type="text" v-model="birthday" required>
          </div>

          <button type="submit" class="button btn-primary">Đăng ký</button>
        </form>
      </div>
      <button class="modal-close is-large" @click="close">X</button>
    </div>
  </div>
</template>

<script>
export default {
  name: "RegisterForm",
  props: ['isActive'],
  data() {
    return {
      username: '',
      password: '',
      passwordConfirm: '',
      name: '',
      contact: '',
      birthday: '',
    }
  },
  methods: {
    close() {
      this.$emit('close');
    },
    register() {
      console.log(`Registering user ${this.username}`);
      this.close();
    }
  },
}
</script>

<style scoped>
.modal {
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  display: flex;
  justify-content: center;
  align-items: center;
  background-color: rgba(0,0,0,0.5);
  transition: opacity 0.3s ease, visibility 0.3s ease;
}

.modal.is-active {
  opacity: 1;
  visibility: visible;
}

.modal-content {
  position: relative;
  background-image: url(https://haycafe.vn/wp-content/uploads/2022/03/Background-bau-troi-background-sky-800x600.jpg); /* Đường dẫn đến hình ảnh */
  padding: 20px;
  border-radius: 5px;
  max-width: 80vh;
  min-width: 40%;
  display: flex;
  flex-direction: column;
  justify-content: space-between;
  transform: translateY(-50px);
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
  justify-content: space-between;
  padding-bottom: 1vh;
  padding-top: 2vh;
  width: 50vh;
  margin: 0 auto;
  font-size: 18px;
  font-weight: 500;
}

.label::after {
  content: "*";
  color: red;
}
.label{caret-color: transparent;}


.input{padding-left: 15px;}
.input{
  border-radius: 25px;
  height: 5vh;
  justify-content: center;
}
</style>
