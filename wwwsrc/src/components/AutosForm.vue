<template>
    <div class="autos-form">
        <!-- try making v-if form inputs to be able to use this one form for all listings -->
        <form class="form" @submit.prevent="submitPosting('autos')">
            <div class="form-group">
                <label for="title">Title: </label>
                <input class="form-control" type="text" name="title" v-model='auto.title' required>
            </div>
            <div class="form-group">
                <label for="make">Make: </label>
                <input class="form-control" type="text" name="make" v-model='auto.make' required>
            </div>
            <div class="form-group">
                <label for="model">Model: </label>
                <input class="form-control" type="text" name="model" v-model='auto.model' required>
            </div>
            <div class="form-group">
                <label for="color">Color: </label>
                <input class="form-control" type="text" name="color" v-model='auto.color' required>
            </div>
            <div class="form-group">
                <label for="year">Year: </label>
                <input class="form-control" type="text" name="year" v-model='auto.year' required>
            </div>
            <div class="form-group">
                <label for="autoDescription">Description: </label>
                <input class="form-control" type="text" name="autoDescription" v-model='auto.autoDescription' required>
            </div>
            <div class="form-group">
                <label for="location">Location: </label>
                <input class="form-control" type="text" name="location" v-model='auto.location' required>
            </div>
            <div class="form-group">
                <label for="imageURL">ImageURL: </label>
                <input class="form-control" type="text" name="imageURL" v-model='auto.imageURL' required>
            </div>
            <div class="form-group">
                <label for="price">Price: </label>
                <input class="form-control" type="text" name="price" v-model='auto.price' required>
            </div>
            <div class="form-group">
                <button type="submit">Submit</button>
            </div>
        </form>
    </div>
</template>

<script>
    export default {
        name: 'autosform',
        data() {
            return {
                auto: {
                    title: '',
                    make: '',
                    model: '',
                    year: '',
                    color: '',
                    autoDescription: '',
                    location: '',
                    imageURL: '',
                    price: ''
                }
            }
        },
        methods: {
            submitPosting(strArg) {
                console.log(this.currentUser)
                this.$store.dispatch('submitPosting', { listing: this.auto, strArg: strArg, creatorId: this.currentUser.id })
            }

        },
        computed: {
            currentUser() {
                return this.$store.state.user
            }
        }
    }

</script>

<style>
</style>