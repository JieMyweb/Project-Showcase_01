<template>
    <el-dialog v-model="IsShowLogin" title="登錄" width="30%" :before-close="handleClose">
        <el-form :model="form" label-width="120px">
            <el-form-item label="用戶名">
                <el-input v-model="form.UserName" />
            </el-form-item>
            <el-form-item label="密碼">
                <el-input v-model="form.Password" type="password" show-password />
            </el-form-item>
            <el-form-item label="驗證碼">
                <el-input v-model="form.ValidateCode" />
                <el-image style="width: 200px; height: 100px;" :src="vaildImages" @click="changeImage" />
            </el-form-item>
            <el-form-item>
                <el-button type="primary" @click="Submit">確定</el-button>
                <el-button @click="CloseLogin">取消</el-button>
            </el-form-item>
        </el-form>
    </el-dialog>
</template>

<script lang="ts" setup>
import { computed, ref, onMounted } from 'vue';
import { useStore } from 'vuex'
import { getToken } from '../http/index'
import { ElMessage } from 'element-plus'
import { oriVaildImages, guid, FormatToken } from '../global/index'
const vaildImages = ref(oriVaildImages.value);
let ValidateKey = "";

//驗證碼加載事件
onMounted(() => {
    const t = guid();
    ValidateKey = t;
    vaildImages.value = oriVaildImages.value + t;
})

//點擊切換驗證碼事件
const changeImage = () => {
    const t = guid();
    ValidateKey = t;
    vaildImages.value = oriVaildImages.value + t;
}

//vuex
const store = useStore()
const IsShowLogin = computed(() => store.state.IsShowLogin)
const handleClose = (done: () => void) => {
    store.commit('CloseLogin')
    done();
};

const CloseLogin = () => {
    store.commit('CloseLogin')
}

const form = ref()
form.value = {
    UserName: "",
    Password: "",
    ValidateCode: "",
};

const Submit = async () => {
    var data = {
        UserName: form.value.UserName,
        Password: form.value.Password,
        ValidateKey: ValidateKey,
        ValidateCode: form.value.ValidateCode,
    }
    var res = (await getToken(data)).data;
    if (res.isSuccess) {
        ElMessage({
            message: '登入成功!',
            type: 'success',
        })
        let user = JSON.parse(FormatToken(res.result));
        localStorage["token"] = res.result;
        //設置全局變量的值
        store.commit('SettingNickName', user.NickName)
        //設置locakStorage,保證葉面刷新後vuex的值可以從裡面讀取,避免刷新後狀態丟失
        localStorage["NickName"] = user.NickName
        //登入成功後隱藏登入框
        store.commit('CloseLogin')
    } else {
        ElMessage.error(res.msg)
    }
}


</script>