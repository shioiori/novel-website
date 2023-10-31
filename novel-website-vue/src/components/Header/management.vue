<template>
    <div class="dropdown management">
        <a
            class=""
            href="#"
            role="button"
            id="dropdownMenuLink"
            data-bs-toggle="dropdown"
            aria-expanded="false"
        >
            <i class="fa-solid fa-gear"></i>
        </a>

        <ul class="dropdown-menu" aria-labelledby="dropdownMenuLink">
            <li><a class="dropdown-item" href="#">Action</a></li>
            <li><a class="dropdown-item" href="#">Another action</a></li>
            <li>
                <a class="dropdown-item" href="#">Something else here</a>
            </li>
        </ul>
    </div>
</template>

<script>
export default {
    name: "management-layout",
};
</script>

<style>
.management {
    margin: auto 0;
}
</style>
