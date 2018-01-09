<template>
  <div id="app">
    <Error></Error>
    <router-view/>
  </div>
</template>

<script>
  import Error from './components/Error'
  export default {
    name: 'app',
    data() {
      return {

      }
    },
    mounted() {
      this.$store.dispatch('authenticate')
    },
    components: {
      Error
    },
    methods: {

    },
    computed: {

    }
  }
</script>

<style>
  #app {
    min-height: 100vh;
  }
</style>