import Vue from 'vue'
import App from './App.vue'
// import './assets/css/global.css'
// import './assets/css/main.css'
import '../node_modules/bootstrap/dist/css/bootstrap.min.css';
import '../node_modules/bootstrap/dist/js/bootstrap.min.js';
import './assets/css/index.css'
import router from './routes';

Vue.config.productionTip = false

new Vue({
  router,
  render: h => h(App),
}).$mount('#app')
