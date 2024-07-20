import axios from 'axios'
import { ref } from 'vue'
// 取得首頁幻燈片
// const json=ref("/json")
// const http=ref("https://localhost:7013/api")
const http=ref("/api")
// export const getBanners = () => {
//     return axios.get(json.value + "/banner.json");
// }
export const getBanners2 = () => {
    return axios.get(http.value + "/Image/GetImages");
}
export const getBooks = (parms:{}) => {
    return axios.post(http.value + "/Book/GetBooks",parms);
}
export const register = (parms:{}) => {
    return axios.post(http.value + "/Login/Register",parms);
}
export const getToken = (parms:{}) => {
    return axios.post(http.value + "/Login/Cheak",parms);
}