<template>
  <div class="home">
    <h1>HOME</h1>
    <button @click="logout">LOGOUT</button>
  </div>
</template>

<script>
  export default {
    name: 'Home',
    data() {
      return {

      }
    },
    mounted() {

    },
    methods: {
      logout() {
        this.$store.dispatch('logout')
      }
    },
    computed: {

    },
    components: {

    }
  }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>