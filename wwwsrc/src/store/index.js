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
        formState = "",
        searchResults: [],
        userPostings: {}
    },
    mutations: {
        handleError(state, err) {
            state.error = err
        },
        setUser(state, user) {
            state.user = user
            // console.log(state.user)
        },
        setMessage(state, msg) {
            state.message = msg
        },
        setSearchResults(state, results) {
            state.searchResults = results
            // console.log(state.searchResults)
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
                    if (res.data) {
                        commit('setUser', res.data)
                        router.push({ name: "Home" })
                    } else {
                        router.push({ name: "Login" })
                    }
                })
                .catch(err => {
                    commit('handleError', err)
                })
        },
        submitRegister({ commit, dispatch }, newUser) {
            account.post('register', newUser)
                .then(res => {
                    commit('setUser', res.data)
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
            payload.listing.CreatorId = payload.creatorId
            console.log(payload.listing)
            api.post(payload.strArg, payload.listing)
                .then(res => {
                    if (res) {
                        //res = whole posting or res.data = whole posting?
                        commit('setMessage', `${payload.strArg} posting successful`)
                    } else {
                        commit('setMessage', `${payload.strArg} posting was not successful`)
                    }
                })
                .catch(err => {
                    commit('handleError', err)
                })
        },
        getAll({ commit, dispatch }, strArg) {
            api(strArg)
                .then(res => {
                    console.log(res)
                    commit('setSearchResults', res.data)
                })
                .catch(err => {
                    commit('handleError', err)
                })
        },
        removeListing({ commit, dispatch }, payload) {
            debugger
            if (payload.currentUser.id == payload.result.creatorId) {
                api.delete(`${payload.strArg}/${payload.result.id}`)
                    .then(res => {
                        if (res) {
                            commit('setMessage', `${payload.strArg} removal successful`)
                            return res
                        } else {
                            commit('setMessage', `${payload.strArg} was not removed`)
                            return res
                        }
                    })
                    .catch(err => {
                        commit('handleError', err)
                    })
                    .then(res => {
                        dispatch('getAll', payload.strArg)
                    })
                    .catch(err => {
                        commit('handleError', err)
                    })
            } else {
                commit('handleError', { message: 'You are not the owner of that listing, and therefore not authorized to remove that listing.' })
            }
        }
        //#endregion
    }
})

export default store