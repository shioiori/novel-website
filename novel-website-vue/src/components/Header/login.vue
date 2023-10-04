<template>
    <div class="col login">
        <management></management>
        <notification></notification>
        <a href="#" data-bs-toggle="modal" data-bs-target="#dangnhap">
            <i class="fa-solid fa-user"></i>
            Tài khoản
            <i class="fa-solid fa-right-to-bracket"></i>
        </a>
    </div>
</template>

<script>
import notification from './notification.vue';
import management from './management.vue';

export default {
    name: "login-layout",
    components: {
        notification,
        management,
    }
};
</script>

<style></style>
