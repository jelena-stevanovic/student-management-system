<template>
  <section>
    <div class="mb-5">
      <h1 class="title">Student Statuses</h1>
    </div>
    <icon v-if="loading" icon="spinner" spin></icon>
    <table v-else class="table">
      <thead>
        <tr>
          <th>Id</th>
          <th>Status Name</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="student in statuses" :key="student.statusId">
            <td>{{ student.statusId }}</td>
          <td>{{ student.statusName }}</td>
        </tr>
      </tbody>
    </table>
  </section>
</template>

<script>
import axios from 'axios';

export default {
  name: 'StudentStatusesIndex',
  data() {
    return {
      loading: false,
      statuses: [],
    };
  },
  mounted() {
    this.getStatuses();
  },
  methods: {
    getStatuses() {
      this.loading = true;
      axios.get('/api/students/statuses')
        .then((data) => {
          this.statuses = data.data;
        })
        .catch((error) => {
          // eslint-disable-next-line no-console
          console.log('Error caught when getting student statuses from the api:');
          // eslint-disable-next-line no-console
          console.log(error);
        })
        .then(() => {
          this.loading = false;
        });
    },
  },
};
</script>
