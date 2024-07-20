<template>
    <div id="footer" class="ft">
        <div class="ft-container">
            <!-- 頁尾 -->
            <div class="ft-nav">
                <a href="/">首頁</a>
                <a href="https://tw.yahoo.com/" target="_blank">關於我們</a>
                <a href="https://tw.yahoo.com/" target="_blank">相關新聞</a>
                <a href="https://tw.yahoo.com/" target="_blank">企業團購</a>
                <a href="https://tw.yahoo.com/" target="_blank">加入我們</a>
                <a href="https://tw.yahoo.com/" target="_blank">友情連結</a>
                <a href="https://tw.yahoo.com/" target="_blank">在線付款</a>
                <a href="https://tw.yahoo.com/" target="_blank">為甚麼選擇我們</a>
            </div>
            <!-- 頁尾end -->
            <!-- 友情連結 -->
            <div class="ft-link">
                <span>友情連結</span>
                <a href="https://tw.yahoo.com/" target="_blank">網站</a>
                <a href="https://shopee.tw/?is_from_login=true" target="_blank">書店</a>
                <a href="https://tw.yahoo.com/" target="_blank">網站</a>
                <a href="https://shopee.tw/?is_from_login=true" target="_blank">書店</a>
                <a href="https://tw.yahoo.com/" target="_blank">網站</a>
                <a href="https://shopee.tw/?is_from_login=true" target="_blank">書店</a>
                <a href="https://tw.yahoo.com/" target="_blank">網站</a>
                <a href="https://shopee.tw/?is_from_login=true" target="_blank">書店</a>
                <a href="https://tw.yahoo.com/" target="_blank">網站</a>
                <a href="https://shopee.tw/?is_from_login=true" target="_blank">書店</a>
                <a href="https://tw.yahoo.com/" target="_blank">網站</a>
                <a href="https://shopee.tw/?is_from_login=true" target="_blank">書店</a>
                <a href="https://tw.yahoo.com/" target="_blank">網站</a>
                <a href="https://shopee.tw/?is_from_login=true" target="_blank">書店</a>
            </div>
        </div>
    </div>
</template>

<script lang="ts" setup>
</script>

<style lang="scss">
#footer{
    font-size: 0;
    background-color: #232628;
    .ft-container{
        width: 1200px;
        margin: 0 auto;
        padding: 40px 0 46px;
        .ft-nav{
            a{
                display: inline-block;
                font-size: 16px;
                line-height: 16px;
                color: #fff;
            }
            a + a{
                padding-left: 28px;
                margin-left: 33px;
                border-left: 1px solid #fff;
            }
        }
        .ft-link{
            margin-top: 20px;
            span{
                font-size: 12px;
                line-height: 16px;
                margin-right: 4px;
                font-weight: bold;
                color: #71797f;
            }
            a{
                font-size: 12px;
                line-height: 16px;
                color: #71797f;
                margin: 0 2px;
            }
        }
    }
}
</style>