import Vue from 'vue'
import App from './App.vue'
import axios from "axios";

Vue.config.productionTip = false
axios.defaults.baseURL='https://localhost:5001/';
// axios.defaults.headers.post['Content-Type'] = 'application/json';
axios.defaults.headers.post['Access-Control-Allow-Origin'] = '*';
axios.defaults.headers.get['Access-Control-Allow-Origin'] = '*';
new Vue({
  render: h => h(App),
}).$mount('#app')
