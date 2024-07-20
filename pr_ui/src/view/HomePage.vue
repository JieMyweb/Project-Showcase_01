<template>
    <div>
        <el-carousel height="150px">
            <el-carousel-item v-for="item in images" :key="item">
                <el-link :href="item.courseUrl" target="_blank">
                    <el-image :src="item.imageUrl"></el-image>
                </el-link>
            </el-carousel-item>
        </el-carousel>
    </div>
    <HomeContent/>
</template>
<script lang="ts" setup>
import { ref,onMounted } from 'vue'
import {getBanners2} from '../http/index'
import HomeContent from '../components/HomeContent.vue'
const images=ref();
// const ishow=ref(false);
onMounted(async() =>{
    // console.log(await getBanners())
    images.value = (await getBanners2()).data
    // ishow.value = true;
})
</script>

<style lang="scss">
.el-carousel__container {
    height: 480px !important;
    margin-top: 10px;
}
</style>