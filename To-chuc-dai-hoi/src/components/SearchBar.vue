<template>
    <div class="search-box">
        <input class="search-input" type="text" placeholder="Tìm kiếm thông tin..." v-model="query" @keyup.enter="this.$store.dispatch('search',query)">
        <button class="search-button" @click="this.$store.dispatch('search',query)">
            <i class="fa fa-search"></i>
        </button>
    </div>
</template>
  
<script>
export default {
    name: "SearchBar",
    data() {
    return {
        query: ''
    };
  },
    methods: {
        focusSearchInput() {
            this.$refs.searchInput.focus();
        }
    },
}
</script>
  
  
<style scoped>
.search-box {
    position: relative;
    margin: 20px auto;
}

.search-input {
    width: 40vh;
    height: 6vh;
    padding-left: 20px; 
    box-sizing: border-box;
    font-size: 18px;
    border-radius: 25vh;
    border: 1px solid #c8c8c8;
    transition: all 0.3s ease-out;
}

.search-input:hover,
.search-input:focus {
    border-color: dodgerblue;
    box-shadow: 0 0 8px 0 dodgerblue;
    transform: scale(1.1);
}

.search-button {
    position: absolute;
    right: -5vh;
    top: 0;
    background: none;
    outline: none;
    border: none;
    cursor: pointer;
    height: 8vh;
    display: flex;
    align-items: center;
}

.search-button .fa {
    margin-right: 7vh;
    margin-bottom: 2vh;
    font-size: 2vh;
    color: #ccc;
    transition: color .3s;
}

.search-button:hover .fa {
    color: dodgerblue;
}

.search-input:focus + .search-button .fa {
    color: dodgerblue;
    transform: scale(1.2);
}
</style>
