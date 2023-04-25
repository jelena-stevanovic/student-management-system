<template>
    <section>
        <div class="mb-5">
            <h1 class="title">All Courses</h1>
        </div>
        <div>
            <button class="btn btn-primary mb-2" @click="$router.push('courses/create')">
                <icon icon="plus" class="mr-2"></icon>
                <span>Add Course</span>
            </button>
        </div>
        <icon v-if="loading" icon="spinner" spin></icon>
        <table v-else class="table">
            <thead>
                <tr>
                    <th>Id</th>
                    <th>CourseName</th>
                    <th></th>
                    <th></th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="course in courses" :key="course.courseId">
                    <td>{{ course.courseId }}</td>
                    <td>{{ course.courseName }}</td>
                    <td>
                        <button class="btn btn-info" v-on:click="viewCourse(course.courseId)">
                            View
                        </button>
                    </td>
                    <td>
                        <button class="btn btn-warning" v-on:click="editCourse(course.courseId)">
                            Edit
                        </button>
                    </td>
                    <td>
                        <button class="btn btn-danger" v-on:click="deleteCourse(course.courseId)">
                            Delete
                        </button>
                    </td>
                </tr>

            </tbody>
        </table>
    </section>
</template>

<script>
import axios from 'axios';

export default {
  name: 'CourseIndex',
  data() {
    return {
      loading: false,
      courses: [],
    };
  },
  mounted() {
    this.getCourses();
  },
  methods: {
    getCourses() {
      this.loading = true;
      axios.get('/api/courses')
        .then((data) => {
          this.courses = data.data;
        })
        .catch((error) => {
          // eslint-disable-next-line no-console
          console.log('Error caught when getting courses from the api:');
          // eslint-disable-next-line no-console
          console.log(error);
        })
        .then(() => {
          this.loading = false;
        });
    },
    viewCourse(id) {
      this.$router.push(`/courses/${id}`);
    },
    editCourse(id) {
      this.$router.push(`/courses/${id}/edit`);
    },
    deleteCourse(id) {
      axios.delete(`/api/courses/${id}`)
        .then(() => {
          this.getCourses();
        })
        .catch((error) => {
          // eslint-disable-next-line no-console
          console.log('Error caught when deleting course from the api:');
          // eslint-disable-next-line no-console
          console.log(error);
        });
    },
  },
};
</script>
