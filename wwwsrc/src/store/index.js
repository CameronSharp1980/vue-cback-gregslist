import Axios from 'axios'
import Vue from 'vue'
import Vuex from 'vuex'
import router from '../router'

let api = Axios.create({
    baseURL: window.location.host.includes("localhost") ? 'http://localhost:5000/api/' : '/api/',
    timeout: 2000,
    withCredentials: true
})

let account = Axios.create({
    baseURL: window.location.host.includes("localhost") ? 'http://localhost:5000/account/' : '/account/',
    timeout: 2000,
    withCredentials: true
})

Vue.use(Vuex)

var store = new Vuex.Store({
    state: {
        error: {},
        user: {}
    },
    mutations: {
        handleError(state, err) {
            state.error = err
        },
        setUser(state, user) {
            state.user = user
        }
    },
    actions: {
        authenticate({ commit, dispatch }) {
            account('authenticate')
                .then(res => {
                    commit('setUser', res.data.data)
                    router.push({ name: "Home" })
                })
                .catch(() => {
                    router.push({ name: "Login" })
                })
        },
        submitLogin({ commit, dispatch }, user) {
            account.post('login', user)
                .then(res => {
                    commit('setUser', res.data.data)
                    router.push({ name: "Home" })
                })
                .catch(err => {
                    commit('handleError', err)
                })
        },
        submitRegister({ commit, dispatch }, newUser) {
            account.post('register', newUser)
                .then(res => {
                    commit('setUser', res.data.data)
                    router.push({ name: "Home" })
                })
                .catch(err => {
                    commit('handleError', err)
                })
        },
        logout({ commit, dispatch }) {
            account.delete('logout')
                .then(res => {
                    commit('setUser', {})
                    router.push({ name: "Login" })
                })
                .catch(err => {
                    commit('handleError', err)
                })
        }
    }
})

export default store