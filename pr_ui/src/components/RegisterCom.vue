<template>
    <el-dialog v-model="IsShowRegister" title="註冊" width="30%" :before-close="handleClose">
        <el-form :model="form" label-width="120px">
            <el-form-item label="暱稱">
                <el-input v-model="form.NickName" />
            </el-form-item>
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
                <el-button @click="CloseRegister">取消</el-button>
            </el-form-item>
        </el-form>
    </el-dialog>
</template>

<script lang="ts" setup>
import { computed, ref, onMounted } from 'vue';
import { useStore } from 'vuex'
import { register } from '../http/index'
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

const store = useStore()
const IsShowRegister = computed(() => store.state.IsShowRegister)

const handleClose = (done: () => void) => {
    store.commit('CloseRegister')
    done();
};
const form = ref()
form.value = {
    NickName: "",
    UserName: "",
    Password: "",
};
const Submit = async () => {
    var data = {
        UserName: form.value.UserName,
        NickName: form.value.NickName,
        Password: form.value.Password,
        ValidateKey: ValidateKey,
        ValidateCode: form.value.ValidateCode,
    }
    var res = (await register(data)).data;
    if (res.isSuccess) {
        ElMessage({
            message: '註冊成功!',
            type: 'success',
        })
        let user = JSON.parse(FormatToken(res.result));
        localStorage["token"] = res.result;
        //設置全局變量的值
        store.commit('SettingNickName', user.NickName)
        //儲存localStorage，保證頁面刷新後vuex的值可以從裡面讀取，避免刷新後狀態丟失
        localStorage["NickName"] = user.NickName
        //登陸成功後隱藏登入框
        store.commit('CloseRegister')
    } else {
        ElMessage.error(res.msg)
    }
}

const CloseRegister = () => {
    store.commit('CloseRegister')
};
</script>