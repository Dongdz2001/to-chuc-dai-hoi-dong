<template>
    <div class="news-container">
        <h1 class="text-3xl font-bold mb-8">Trang tin tức</h1>
        <div v-if="loading" class="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 gap-8">
            <div v-for="i in 3" :key="i" class="border border-blue-300 shadow rounded-md p-4 max-w-sm w-full mx-auto">
                <div class="animate-pulse flex space-x-4">
                    <div class="rounded-full bg-slate-200 h-10 w-10"></div>
                    <div class="flex-1 space-y-6 py-1">
                        <div class="h-2 bg-slate-200 rounded"></div>
                        <div class="space-y-3">
                            <div class="grid grid-cols-3 gap-4">
                                <div class="h-2 bg-slate-200 rounded col-span-2"></div>
                                <div class="h-2 bg-slate-200 rounded col-span-1"></div>
                            </div>
                            <div class="h-2 bg-slate-200 rounded"></div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div v-else class="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 gap-8">
            <div v-for="article in articles" :key="article.id" class="news-card shadow-lg rounded-md overflow-hidden">
                <a href="https://baochinhphu.vn/khai-mac-hoi-nghi-trung-uong-5-khoa-xiii-102220504082007827.htm">
                <img :src="article.image" alt="Article Image" class="w-full h-48 object-cover">
                <div class="p-4">
                    <h2 class="text-xl font-bold mb-2 title-information">{{ truncateText(article.title, 40) }}</h2>
                    <p class="text-gray-600">{{ truncateText(article.description, 80, true) }}</p>
                    <p class="text-gray-400 mt-2"> {{ article.location }} -- {{  formatDate(article.date) }}</p>
                </div>
            </a>
            </div>
        </div>
    </div>
</template>


<script>
export default {
    name: "NewsPage",
    data() {
        return {
            articles: [],
            loading: true,  // Trạng thái loading mới
        };
    },
    methods: {
        async fetchArticles() {
            try {
                this.loading = true;  // Bắt đầu hiển thị hiệu ứng loading
                const response = await fetch("https://localhost:7257/api/Tintuc");
                const data = await response.json();
                this.articles = data;
                this.loading = false;  // Dừng hiển thị hiệu ứng loading khi dữ liệu đã được tải
            } catch (error) {
                this.loading = true;  // Dừng hiển thị hiệu ứng loading khi có lỗi
                console.error(error);
            }
        },
        formatDate(date) {
           
            // Định dạng lại ngày tháng theo yêu cầu của bạn
            return date;
        },
        truncateText(text, maxLength, useEllipsis = false) {
            if (text.length <= maxLength) {
                return text;
            } else {
                if (useEllipsis) {
                    return text.substr(0, maxLength) + "...";
                } else {
                    return text.substr(0, maxLength);
                }
            }
        },
    },
    mounted() {
        this.fetchArticles();
    },
};
</script>



<style scoped>
.title-information {
    word-wrap: break-word;
    overflow-wrap: break-word;
    hyphens: auto;
    display: -webkit-box;
    -webkit-line-clamp: 3;
    -webkit-box-orient: vertical;
    overflow: hidden;
    text-overflow: ellipsis;
}

.news-container {
    max-width: 1200px;
    margin: 0 auto;
    padding: 20px;
}

.news-card {
    background-color: #ffffff;
    transition: transform 0.3s;
}

.news-card:hover {
    transform: translateY(-2px) scale(1.05);
}
</style>



