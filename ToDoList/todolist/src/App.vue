<template>
  <div id="app">
    <div class="card">
      <h1>{{ title }}</h1>
      <div class="form-control">

        <input type="text" v-bind:placeholder="placeholderString" v-bind:value="inputValue"
               v-on:input="inputChangeHandler" v-on:keypress.enter="addNewNote" />
      </div>

      <button class="btn" v-on:click="addNewNote">Добавить</button>
      <hr />
      <ul class="list" v-if="notes.length !== 0">
        <li class="list-item"
            v-for="(note, idx) in notes"
        :key="idx">
          <!-- ({{ idx + 1 }})--> {{ note.action }}
          <button class="btn danger" v-on:click="removeNote(idx)"> удалить</button>
        </li>
      </ul>
      <div v-if="notes.length === 0">Заметок пока нет</div>
    </div>
  </div>
</template>

<script>

import axios from "axios";
//asdfad
export default {
  name: 'App',
  data() {
    return {
      placeholderString: 'Введите текст',
      title: 'Список заметок',
      inputValue: '',
      notes: [{id: undefined, action: undefined}]
    }
  },
  mounted() {
    this.fillNotes();
  },
  methods: {
    inputChangeHandler(event) {
      // console.log('inputChangeHandler', event.target.value)
      this.inputValue = event.target.value
    },
    async addNewNote() {
      // const customHeaders = {
      //   'accept': 'text/plain',
      //   'content-type': 'application/json; charset=utf-8',
      // };
      if (this.inputValue !== '') {
        await axios.post('/ToDoList', { id: 0, action: this.inputValue});
        await this.fillNotes();
        this.inputValue = ''
      }
    },
    async fillNotes() {
      const response = await axios.get('/ToDoList')
      console.log(response);
      this.notes = response.data;
    },
    async removeNote(idx) {
      console.log(this.notes[idx]);
      await axios.delete('/ToDoList', { data: { id: this.notes[idx].id, actions: this.notes[idx].action } })
      await this.fillNotes();
    }
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
* {
  box-sizing: border-box;
}

body {
  font-family: Inter, Roboto, Oxygen, Fira Sans, Helvetica Neue, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  font-size: 16px;
  color: #2c3e50;
  background: #2c3e50;
}

hr {
  margin: 1rem 0;
}

strong,
.bold {
  font-weight: 500;
}

ol,
p,
ul {
  line-height: 1.7;
}

a {
  color: #3eaf7c;
  font-weight: 500;
  text-decoration: none;
}

h1,
h2,
h3,
h4,
h5,
h6 {
  font-weight: 500;
  line-height: 1.45;
}

h1 {
  font-size: 2.2rem;
  font-weight: 600;
}

h2 {
  font-size: 1.65rem;
  padding-bottom: 0.3rem;
  border-bottom: 1px solid #eaecef;
}

h3 {
  font-size: 1.35rem;
}

.primary {
  color: #42b983;
}

.danger {
  color: #e53935;
}

.btn {
  color: #42b983;
  position: relative;
  place-content: center;
  place-items: center;
  width: fit-content;
  border-radius: 99px;
  letter-spacing: 0.05em;
  border: 1px solid #42b983;
  text-decoration: none;
  text-transform: uppercase;
  margin-right: 10px;
  padding: 0.5rem 1.5rem;
  white-space: nowrap;
  font-weight: 700;
  outline: none;
  background: #fff;
  transition: all 0.22s;
}

.btn:hover {
  cursor: pointer;
  opacity: 0.8;
}

.btn:active {
  box-shadow: inset 1px 1px 1px rgba(0, 0, 0, 0.3);
}

.btn.primary {
  background: #42b983;
  color: #fff;
}

.btn.danger {
  background: #e53935;
  color: #fff;
  border-color: #e53935;
}

.container {
  margin: 0 auto;
  max-width: 1000px;
}

.pt-5 {
  padding-top: 5rem;
}

.form-control {
  position: relative;
  margin-bottom: 0.5rem;
}

.form-control input {
  margin: 0;
  outline: none;
  border: 2px solid #ccc;
  display: block;
  width: 100%;
  color: #2c3e50;
  padding: 0.5rem 1.5rem;
  border-radius: 3px;
  font-size: 1rem;
}

.form-control label {
  display: block;
  margin: 0 0 0.3rem 0.3rem;
  font-weight: 500;
}

.form-control input:active,
.form-control input:focus {
  transition: border 0.22s;
  border: 2px solid #42b983;
}

.card {
  padding: 1rem;
  border-radius: 10px;
  box-shadow: 2px 3px 10px rgba(0, 0, 0, 0.2);
  background: #fff;
}

.card.center {
  display: flex;
  flex-direction: column;
  align-items: center;
}

.list {
  margin: 0;
  padding: 0;
  list-style: none;
}

.list-item {
  display: flex;
  align-items: center;
  justify-content: space-between;
  padding: 0.5rem 0;
}

</style>
