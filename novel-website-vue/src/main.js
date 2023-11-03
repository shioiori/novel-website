import Vue from 'vue'
import App from './App.vue'
// import './assets/css/global.css'
// import './assets/css/main.css'
import '../node_modules/bootstrap/dist/css/bootstrap.min.css';
import '../node_modules/bootstrap/dist/js/bootstrap.min.js';
import './assets/css/index.css'
import router from './routes';
import store from './store/store'

Vue.config.productionTip = false

export const EventBus = new Vue();

new Vue({
  router,
  store,
  render: h => h(App),
}).$mount('#app')
