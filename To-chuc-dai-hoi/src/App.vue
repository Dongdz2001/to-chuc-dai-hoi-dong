<template>
  <img class="banner" src=".//assets//HusBaner.png" alt="Đại hội chào mừng banner" />

  <nav class="home-bar">
    <router-link to="/" class="nav-link">Trang Chủ</router-link>
    <router-link to="/hoatdong" class="nav-link">Hoạt Động</router-link>
    <router-link to="/tintuc" class="nav-link">Tin Tức</router-link>
    <SearchBar class="nav-search" style="margin-right: 3vh;" />
    <div class="button-group" style="display: flex;">
      <button @click="handleLoginClick" class="text-button">{{ isLoggedIn ? 'Đăng xuất' : 'Đăng nhập' }}</button>
      <span style="padding: 1vh;">/</span>
      <button @click="handleRegisterClick" class="text-button">{{ isRegistered ? "" : 'Đăng ký' }}</button>
    </div>
  </nav>

  <router-view style="width: 100%; height: 100%;padding: 1vh;" />

  <FooterHUS  />
  

  <div class="modal-overlay" v-if="showRegisterForm">
      <div class="modal-container">
        <div class="modal-content">
          <button @click="closeForm" class="modal-close"></button>
          <RegisterForm @close="closeForm" :isActive="showRegisterForm" />
        </div>
      </div>
    </div>
    <div class="modal-overlay" v-if="showLoginForm">
      <div class="modal-container">
        <div >
          <button @click="closeForm" class="modal-close"></button>
          <LoginForm @close="closeForm" :isActive="showLoginForm" />
        </div>
      </div>
    </div>
</template>

<script>
import FooterHUS from './components/FooterHUS.vue';
import SearchBar from './components/SearchBar.vue';
import RegisterForm from './components/RegisterForm.vue';
import LoginForm from './components/LoginForm.vue';

export default {
  components: {
    FooterHUS,
    SearchBar,
    RegisterForm,
    LoginForm,
  },
  data() {
    return {
      showRegisterForm: false,
      showLoginForm: false,
      // Add showLoginForm if needed
      // showLoginForm: false,
      isLoggedIn: false,
      isRegistered: false
    };
  },
  methods: {
    handleRegisterClick() {
      this.showRegisterForm = true;
    },
    closeForm() {
      this.showRegisterForm = false;
      this.showLoginForm = false;
    },
    handleLoginClick() {
      this.showLoginForm = true;
    },
    // Add closeLoginForm and handleLoginClick methods if needed
  },
};
</script>

<style scoped>
.home-bar {
  box-sizing: border-box;
  /* includes padding and border in the element's total width and height */
  width: 100vw;
  /* full width */
  display: flex;
  justify-content: space-between;
  align-items: center;
  /* Can giữa theo chiều cao */
  padding-left: 1em;
  background: linear-gradient(90deg, rgb(6, 47, 88) 0%, rgb(58, 123, 137) 50%, rgb(204, 209, 218) 100%);
  /* cooler gradient */
  height: 10vh;
}


.nav-link {
  margin-right: 1em;
  text-decoration: none;
  color: #fff;
  line-height: 60px;
  transition: color 0.3s, transform 0.3s;
  padding-left: 3vh;
  font-weight: 500;
  font-size: 2.5vh;

}

.banner {
  margin-bottom: -31vh;
  margin-top: -20vh;
  width: 100%;
  height: 110vh;
  object-fit: cover;
  clip-path: inset(15% 0 28% 0);
  object-position: center center;
}


.nav-link:hover {
  color: #000;
  transform: scale(1.2);
}

.footer {
  position: absolute;
  bottom: 0;
  width: 100%;
  height: 60px;
  background: linear-gradient(90deg, rgb(6, 47, 88) 0%, rgb(58, 123, 137) 50%, rgb(204, 209, 218) 100%);
  display: flex;
  justify-content: space-around;

  color: white;
}

.footer-content {
  display: flex;
  align-items: center;
}

.hus-logo {
  width: auto;
  height: 50px;

}

.date-time {
  padding-top: 5px;
  margin-right: 15px;

}

.footer-text {
  font-size: 20px;
  animation: color-change 5s infinite;
}

.footer-date-content {
  width: fit-content;
  margin-left: 100vh;
  display: flex;
  justify-content: end;
}

@keyframes color-change {
  0% {
    color: white;
  }

  50% {
    color: yellow;
  }

  100% {
    color: white;
  }
}

.login-btn {
  /* Style for the login button */
  cursor: pointer;
  background-color: transparent;
  border: none;
  color: #fff;
  transition: color 0.3s;
}

.login-btn:hover {
  color: #000;
  transform: scale(1.1);
}

.text-button {
  background: none;
  border: none;
  padding: 0;
  /* No extra space around the text */
  font-family: inherit;
  font-size: inherit;
  color: inherit;
  cursor: pointer;
  text-decoration: none;
  transition: transform 0.3s, filter 0.3s;
}


.text-button:hover {
  text-decoration: none;
}

.button-group {
  height: fit-content;
  padding-right: 3vh;
  display: flex;
  align-items: center;
}

.text-button {
  background: none;
  border: none;
  padding: 0;
  font-family: inherit;
  font-size: inherit;
  color: inherit;
  cursor: pointer;
  text-decoration: none;
  transition: transform 0.3s, filter 0.3s;
}

.text-button:hover {
  transform: scale(1.1);
  /* Increase size on hover */
  filter: brightness(1.2);
  /* Add brightness effect on hover */
}

.text-button:active {
  transform: scale(0.9);
  /* Decrease size when clicked */
}

.modal-overlay {
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background-color: rgba(0, 0, 0, 0.5);
  display: flex;
  justify-content: center;
  align-items: center;
  z-index: 9999;
}

.modal-container {
  max-width: 400px;
}




.modal-close {
  position: absolute;
  top: 10px;
  right: 10px;
  width: 20px;
  height: 20px;
  background-color: transparent;
  border: none;
  cursor: pointer;
  outline: none;
}

.modal-close:before,
.modal-close:after {
  content: '';
  position: absolute;
  width: 2px;
  height: 16px;
  background-color: #333;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
}

.modal-close:before {
  transform: translate(-50%, -50%) rotate(45deg);
}

.modal-close:after {
  transform: translate(-50%, -50%) rotate(-45deg);
} 
</style>
