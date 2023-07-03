import { createApp } from 'vue'
import { createRouter, createWebHashHistory } from 'vue-router'
import 'bootstrap/dist/css/bootstrap.css'
import './style.css'
import '@fortawesome/fontawesome-free/css/all.css'
import App from './App.vue'
import TrangChu from './router/TrangChu.vue'
import HoatDong from './router/HoatDong.vue'
import TinTuc from './router/TinTuc.vue'
import './index.css'
import store from 'D:/JavaScript/vueJS/To-chuc-dai-hoi/src/components/store/store.js';

const routes = [
  { path: '/', component: TrangChu },
  { path: '/hoatdong', component: HoatDong },
  { path: '/tintuc', component: TinTuc },
]

const router = createRouter({
  history: createWebHashHistory(),
  routes, // short for `routes: routes`
})

const app = createApp(App)

app.use(router)
app.use(store)
app.mount('#app')
