    import { createRouter,createWebHistory } from "vue-router"
    import HomePage from "./view/HomePage.vue"
    import LoveBook from "./view/LoveBook.vue"
    import BirthdayBook from "./view/BirthdayBook.vue"
    import FriendBook from "./view/FriendBook.vue"
    import WeddingBook from "./view/WeddingBook.vue"
    import BookDetail from "./view/BookDetail.vue"
    import BookPay from "./view/BookPay.vue"
    import PersomCenter from "./view/PersonCenter.vue"
    const router = createRouter({
        history:createWebHistory(),
        routes: [
            {path:'/',component:HomePage},
            {path:'/loveBook',component:LoveBook},
            {path:'/birthdayBook',component:BirthdayBook},
            {path:'/friendBook',component:FriendBook},
            {path:'/weddingBook',component:WeddingBook},
            {path:'/detail',component:BookDetail},
            {path:'/pay',component:BookPay},
            {path:'/persomCenter',component:PersomCenter},
        ],
    })
    export default router