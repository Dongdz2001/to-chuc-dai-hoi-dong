<template>
  <div v-if="isLoading" class="loading-container">
    <div class="spinner"></div>
  </div>
  <div v-else>
    <div>
      <h2 class="animated-title text-center">DANH SÁCH ĐẠI BIỂU THAM DỰ</h2>
      <div style="display: flex; justify-content: space-between;">
        <ImportButton @reload-data="$store.dispatch('getALLDaiBieu')" :listMembers="members" />
        <Dropdown :listArray="members" />
      </div>
    </div>
    <table>
      <thead>
        <tr>

          <th>Tên</th>
          <th>Tuổi</th>
          <th>Chức vụ</th>
          <th>Nơi công tác</th>
          <th>Liên hệ</th>
          <th>Trạng thái</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="member in members" :key="member.id" :class="{ 'user-row': member.id == idUser }">

          <td>{{ member.name }}</td>
          <td>{{ member.age }}</td>
          <td>{{ member.position }}</td>
          <td>{{ member.workPlace }}</td>
          <td>{{ member.contact }}</td>
          <td>
            <div class="container" v-if="member.id == idUser">
              <div class="row">
                <div class="col-4 d-flex justify-content-between" style="margin: 0 auto;">
                  <i class="fas fa-check" :class="getIconClass('check', member)" @click="setActiveIcon('check')"
                    style="margin-right: 2vh;"></i>
                  <i class="fas fa-times" :class="getIconClass('times', member)" @click="setActiveIcon('times')"
                    style="margin-right: 2vh;"></i>
                  <i class="fas fa-lightbulb" :class="getIconClass('lightbulb', member)"
                    @click="setActiveIcon('lightbulb')"></i>


                </div>
              </div>
            </div>
            <div v-else>
              <span v-if="member.status == 'check'">
                <i class="fas fa-check" style="color: green; margin-right: 0.5em;"></i>
                Tham gia
              </span>
              <span v-else-if="member.status == 'times'">
                <i class="fas fa-times" style="color: red; margin-right: 0.5em;"></i>
                Không tham gia
              </span>
              <span v-else-if="member.status == 'lightbulb'">
                <i class="fas fa-lightbulb" style="color: orange; margin-right: 0.5em;"></i>
                Đang suy nghĩ
              </span>
            </div>

          </td>

        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import Dropdown from '../components/DropDown.vue';
import ImportButton from '../components/ImportButton.vue';
import axios from 'axios';
export default {
  name: "TrangChu",
  components: {
    Dropdown,
    ImportButton,
  },
  data() {
    return {
      idUser: "236eeba7-b0d5-433d-8b3a-fa72c4dcb50e",
      activeIcon: null, // icon đã chọn
    };
  },
  computed: {
    isLoading() {
      return this.$store.state.isLoadingTrangChu; 
    },
    members() {
      return this.$store.state.members;
    },
  },
  methods: {
    putUpdateStatusDaiBieu(id, member) {
      axios.put(`https://localhost:7257/api/DaiBieu/${id}`, member)
        .then(response => {
          console.log('Post updated successfully!');
        })
        .catch(error => {
          console.error(error);
        });
    },

    setActiveIcon(icon) {
      this.$store.state.members = this.members.map(member => {
        if (member.id === this.idUser) {
          member.status = icon;
          this.putUpdateStatusDaiBieu(member.id, member);
        }
        return member;
      });
    },
    getIconClass(icon, member) {
      if (member.id === this.idUser) {
        return {
          'icon': true,
          'active': member.status === icon
        };
      } else {
        return 'icon';
      }
    },

  

  },

  // Sử dụng lifecycle hooks nếu cần lấy dữ liệu từ server
  mounted() {
    this.$store.dispatch('getALLDaiBieu');
  }
};

</script>


<style scoped>
table {
  user-select: none;
  width: 100%;
  border-collapse: collapse;
  transition: all 0.3s ease;

}

table:hover {
  box-shadow: 0px 0px 30px rgba(0, 0, 0, 0.1);
}

th,
td {

  border: 1px solid #ddd;
  padding: 15px;
  text-align: center;
}

th {
  background-color: #4CAF50;
  color: white;
}


tr:hover {
  background-color: #ddd;
}

.fas.fa-check {
  color: green;
}


.fas.fa-times {
  color: red;
}

.fas.fa-lightbulb {
  color: orange;
}

.user-row {
  background-color: rgb(108, 235, 104);
}

@keyframes pulse {
  0% {
    transform: scale(1);
    font-weight: 700;
    color: #062AB9;
    /* Màu sắc */
    opacity: 1;
  }

  50% {
    transform: scale(1.1);
    font-weight: 700;
    color: #59DC9B;
    /* Màu sắc */
    opacity: 0.96;
  }

  100% {
    transform: scale(1);
    font-weight: 700;
    color: #002DE3;
    /* Màu sắc */
    opacity: 1;
  }
}

.animated-title {
  text-align: center;
  font-size: 3em;
  /* Cỡ chữ */

  font-family: 'Montserrat', sans-serif;
  text-shadow: 1px 1px 2px rgba(250, 15, 15, 0.5);
  /* Đổ bóng cho chữ */
  animation: pulse 2s ease-in-out infinite;
}

.icon {
  transition: transform 0.3s;
}

.icon.active {
  transform: scale(1.8);
}

.fas.fa-check,
.fas.fa-times,
.fas.fa-lightbulb {
  font-size: 23px;
}



.loading-container {
  display: flex;
  justify-content: center;
  align-items: center;
  height: 100vh;
}

.spinner {
  border: 16px solid #f3f3f3;
  border-radius: 50%;
  border-top: 16px solid #3498db;
  width: 120px;
  height: 120px;
  -webkit-animation: spin 2s linear infinite;
  /* Safari */
  animation: spin 2s linear infinite;
}

/* Safari */
@-webkit-keyframes spin {
  0% {
    -webkit-transform: rotate(0deg);
  }

  100% {
    -webkit-transform: rotate(360deg);
  }
}

@keyframes spin {
  0% {
    transform: rotate(0deg);
  }

  100% {
    transform: rotate(360deg);
  }
}</style>
