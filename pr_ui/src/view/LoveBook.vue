<template>
    <div class="common-layout">
        <el-container>
            <el-header>
                <div class="hd">
                    <a class="more" href="/loveBook">
                        更多精選
                        <span class="icon icon-arrow-right"></span>
                    </a>
                    <h3>
                        <a href="loveBook">每日精選</a>
                        <span>每日精選時時更新</span>
                    </h3>
                </div>
            </el-header>
            <el-container>
                <el-aside width="300px">
                    <el-image style="margin-top: 20px" src="/images/Banner.png"></el-image>
                </el-aside>
                <el-main>
                    <el-image style="display:inherit;width: 1048px;margin-top: -20px;"
                        src='/images/theme/flower_bannerLove_109006.jpg'></el-image>
                    <div class="grid-wrapper">
                        <div class="grid-item" v-for="item in list" :key="item">
                            <el-link>
                                <div class="grid-panel">
                                    <div class="img-box">
                                        <el-image class="list-image" :src="item.image"></el-image>
                                    </div>
                                    <div class="info-cont">
                                        <div class="price">
                                            <span class="price-sign">¥</span>
                                            <span class="price-num">{{ item.price }}</span>
                                        </div>
                                        <div class="title">
                                            <span class="product-title">{{ item.title }}</span>
                                        </div>
                                    </div>
                                </div>
                            </el-link>
                        </div>
                    </div>
                </el-main>
            </el-container>
        </el-container>
    </div>
</template>
<script setup>
import { getBooks } from '../http/index'
import { ref, onMounted } from 'vue';
const list = ref()
onMounted(async () => {
    let parms = {
        Id: 0,
        Type: 1
    }
    // console.log((await getBooks()).data)
    list.value = (await getBooks(parms)).data.result
})
</script>
<style lang="scss">
.common-layout {
    padding-left: 16.5%;
    background-color: #f7f9fa;
}

.more {
    font-size: 14px;
    line-height: 30px;
    color: #71797f;
    float: right;
    margin-right: 21%;
}

.hd {
    text-align: initial;

    h3 {
        font-size: 26px;
        line-height: 30px;
        color: #232628;
        font-weight: bold;

        a {
            color: inherit;
        }

        span {
            padding-left: 15px;
            margin-left: 16px;
            font-size: 20px;
            line-height: 24px;
            font-weight: normal;
            border-left: 1px solid #71797f
        }
    }
}

.fl-products {
    width: 912px;
    vertical-align: top;

    .fl-products-item {
        display: inline-block;
        width: 212px;
        margin-left: 16px;
        margin-bottom: 16px;
        background-color: #fff;
        vertical-align: top;

        .product-title {
            max-width: 100%;
            overflow: hidden;
            -o-text-overflow: ellipsis;
            text-overflow: ellipsis;
            white-space: nowrap;
            font-size: 16px;
            line-height: 20px;
        }

        .product-price {
            margin-top: 5px;
            font-size: 16px;
            font-weight: bold;
            line-height: 20px;
        }
    }
}
</style>