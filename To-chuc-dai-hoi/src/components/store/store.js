import { createStore } from 'vuex'
import axios from 'axios';
export default createStore({
  state: {
    result: 0,
    isLoadingTrangChu: false,
    members: [],
    originalMembers: []  // add this to store the original list of members
  },
  mutations: {
    increment (state) {
      state.result++
    },
    setMembers(state, members) {
      state.members = members;
      state.originalMembers = members; // also store the members into originalMembers
    },
    filterMembers(state, query) {
      if (query) {
        state.members = state.originalMembers.filter(member => member.name.toLowerCase().includes(query.toLowerCase()));
      } else {
        state.members = state.originalMembers;
      }
    },
    setIsLoading(state, isLoading) {
      state.isLoadingTrangChu = isLoading;
    }
  },
  getters: {
  },
  actions: {
    async getALLDaiBieu({ commit }) {
      commit('setIsLoading', true);
      await axios.get('https://localhost:7257/api/DaiBieu').then(response => {
        commit('setMembers', response.data);
        commit('setIsLoading', false);
      }).catch(error => {
        console.log(error);
        commit('setIsLoading', false);
      });
    },
    search({ commit }, query) {
      commit('filterMembers', query);
    }
  },
  modules: {
  }
})
