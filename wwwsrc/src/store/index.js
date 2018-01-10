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
        message: "",
        user: {},
        searchResults: {},
        userPostings: {}
    },
    mutations: {
        handleError(state, err) {
            state.error = err
        },
        setUser(state, user) {
            state.user = user
        },
        setMessage(state, msg) {
            state.message = msg
        }

    },
    actions: {

        //#region UserAuth
        authenticate({ commit, dispatch }) {
            account('authenticate')
                .then(res => {
                    // console.log("Response @ auth: ", res.data)
                    if (res.data) {
                        commit('setUser', res.data)
                        router.push({ name: "Home" })
                    } else {
                        router.push({ name: "Login" })
                    }
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
        },
        //#endregion

        //#region Listing Methods
        submitPosting({ commit, dispatch }, payload) {
            api.post(payload.strArg, payload.listing)
                .then(res => {
                    if (res) {
                        //res = whole posting or res.data = whole posting?
                        commit('setMessage', `${payload.strArg} Posting Successful`)
                    } else {
                        commit('setMessage', `${payload.strArg} Posting Unsuccessful`)
                    }
                })
                .catch(err => {
                    commit('handleError', err)
                })
        }
        //#endregion
    }
})

export default store