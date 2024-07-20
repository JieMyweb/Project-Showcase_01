<template>
  <div>
    <el-row>
      <el-col :span="24">
        <ul>
          <li v-if="store.state.NickName == undefined" @click="OpenLogin">
            <el-link :underline="false">登入</el-link>
          </li>
          <li v-if="store.state.NickName == undefined" @click="OpenRegister">
            <el-link :underline="false">註冊</el-link>
          </li>
          <li v-if="store.state.NickName != undefined">
            <el-link :underline="false">{{store.state.NickName}}</el-link>
          </li>
          <li v-if="store.state.NickName != undefined">
            <el-link :underline="false" href="/src/view/PersonCenter.vue">個人中心</el-link>
          </li>
          <li v-if="store.state.NickName != undefined" @click="LogOut">
            <el-link :underline="false">登出</el-link>
          </li>
        </ul>
      </el-col>
    </el-row>
    <el-row>
      <el-col :span="8">
        <el-link :underline="false" href="/">
          <el-image style="width: 200px; height: 100px" src="/images/logo.jpg" fit="contain" />
        </el-link>
      </el-col>
      <el-col :span="8">
        <el-input class="w-50 m-2" style="margin-top: 30px" size="large" placeholder="商品搜尋" />
      </el-col>
      <el-col :span="8">
        <div class="service-item">
          <a id="header-chat" href="javascript:void(0);">
            <el-icon class="icon-headset">
                <Service />
            </el-icon>
            <span class="service-item-info">在線客服</span>
          </a>
        </div>
      </el-col>
    </el-row>
    <el-row>
      <el-col :span='20'>
        <el-menu class="el-menu-header" mode="horizontal" router>
          <el-menu-item index="/">首頁</el-menu-item>
          <el-menu-item index="/loveBook">每日精選</el-menu-item>
          <el-menu-item index="/birthdayBook">暢銷排行</el-menu-item>
          <el-menu-item index="/friendBook">必看清單</el-menu-item>
          <el-menu-item index="/weddingBook">推薦清單</el-menu-item>
        </el-menu>
      </el-col>
    </el-row>
  </div>
  <LoginCom />
  <RegisterCom />
</template>

<script lang="ts" setup>
import { useStore } from 'vuex'
import LoginCom from './LoginCom.vue';
import RegisterCom from './RegisterCom.vue';
import { Service } from '@element-plus/icons-vue'

const store = useStore()
const OpenLogin = () =>{
  store.commit('OpenLogin')
}
const OpenRegister = () =>{
  store.commit('OpenRegister')
}

const LogOut = ()=>{
  //請空vuex的localStorage
  localStorage.removeItem('NickName');
  localStorage.removeItem('token');
  store.commit('SettingNickName', undefined)
}
</script>

<style lang="scss">
ul {
  list-style: none;
  padding-left: 80%;

  li {
    float: left;
    margin-left: 20px;
  }
}

.service-item {
  display: inline-block;
  font-size: 14px;
  color: #c0c0c0;
  vertical-align: top;
  line-height: 47px;
  margin-top: 25px;
  margin-left: -200px;

  a {
    text-decoration: none;
    color: inherit;
  }

  .icon-headset {
    // background-position: -34px -102px;
    font-size: 24px;
    position: relative;
    top: 5px; /* 調整這個值來改變圖標的垂直位置 */
    // margin-right: 8px;
    // display: inline-block;
    // background-image: url(//localhost:8081/images/01.png);
    // background-repeat: no-repeat;
    // vertical-align: top;
    color: #ff821d;
  }
}

.el-menu-header {
  margin-left: 29% !important;
  border-bottom: 0px !important;

  .el-menu-item {
    width: 170px !important;
  }
}
</style>
