<template>
  <div class="modal" v-if="isActive">
    <div class="modal-background" @click="close"></div>
    <div class="modal-content">
      <div class="box">
        <h4 class="text-4xl"> Đăng Nhập </h4>
        <form @submit.prevent="Login">
          <div class="field">
            <label class="label">Tên đăng nhập</label>
            <input class="input" type="text" v-model="username" required>
          </div>
          

          <div class="field">
            <label class="label">Mật khẩu</label>
            <input class="input" type="password" v-model="password" required>
          </div>

          <button type="submit" class="button btn-primary" style="font-size: 25px;">Đăng nhập</button>
        </form>
      </div>
      
      <button class="modal-close is-large" @click="close">X</button>
    </div>
    
  </div>
</template>
  
<script>
export default {
  name: "LoginForm",
  props: ['isActive'],
  data() {
    return {
      username: '',
      password: '',
    }
  },
  methods: {
    close() {
      this.$emit('close');
    },
    Login() {
      console.log(`Logining user ${this.username}`);
      this.close();
    }
  },
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
  background-image: url(https://haycafe.vn/wp-content/uploads/2022/03/Background-bau-troi-background-sky-800x600.jpg);
  /* Đường dẫn đến hình ảnh */
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
  
.input {
  padding-left: 15px;
  border-radius: 25px;
  height: 5vh;
}

.button {
  border: 1pt solid black;
  margin-top: 5vh;
}
</style>
  