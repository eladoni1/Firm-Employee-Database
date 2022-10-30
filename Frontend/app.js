// For routing pass

const routes = [
    {path: '/Home', component: home},
    {path: '/Employee', component: employee},
    {path: '/Department', component: department}
]
const router = VueRouter.createRouter({history: VueRouter.createWebHashHistory(), routes})

const app = Vue.createApp().use(router).mount('#app')