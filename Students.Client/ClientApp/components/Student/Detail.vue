<template>
    <div>
        <div class="mb-5">
            <h1 class="title">Create Student</h1>
        </div>
        <div class="row">
            <div class="col-md-4">
                <div class="form-group">
                    <label class="label">Student Id</label>
                    <input v-model="studentId" class="form-control" type="text" disabled />
                </div>
                <div class="form-group">
                    <label class="label">FirstName</label>
                    <input v-model="firstName" class="form-control" type="text" disabled />
                </div>
                <div class="form-group">
                    <label class="label">LastName</label>
                    <input v-model="lastName" class="form-control" type="text" disabled />

                </div>
                <div class="form-group">
                    <label class="label">Enrollment Year</label>
                    <input v-model="enrollmentYear" class="form-control" type="text" disabled />
                </div>
                <div class="form-group">
                    <label class="label">Status</label>
                    <input v-model="statusName" class="form-control" type="text" disabled />
                </div>
                <div class="form-group">
                    <label class="label">Student Number</label>
                    <input v-model="studentNumber" class="form-control" type="text" disabled />
                </div>

                <label class="label">Enrolled Courses</label>
                <table class="table">
                    <tbody>
                        <tr v-for="course in enrolledCourses" :key="course.courseId">
                            <td>{{ course.courseId }}</td>
                            <td>{{ course.courseName }}</td>
                            <td> </td>
                        </tr>
                    </tbody>
                </table>

                <div class="form-group is-grouped">
                    <div class="control">
                        <a class="button is-link is-light"
                           @click="$router.push('/students')">
                            Back
                        </a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import axios from 'axios';

export default {
  data() {
    return {
      studentId: '',
      firstName: '',
      lastName: '',
      enrollmentYear: '',
      statusName: '',
      studentNumber: '',
      enrolledCourses: [],
    };
  },
  computed: {
    id() {
      return this.$route.params.id;
    },
  },
  created() {
    axios
      .get(`/api/students/${this.id}`)
      .then((res) => {
        this.studentId = res.data.studentId;
        this.firstName = res.data.firstName;
        this.lastName = res.data.lastName;
        this.enrollmentYear = res.data.enrollmentYear;
        this.statusName = res.data.status?.statusName;
        this.studentNumber = res.data.studentNumber;
        this.enrolledCourses = res.data.studentCourses?.map((sc) => sc.course);
      })
      .catch((error) => {
        // eslint-disable-next-line no-console
        console.log('Error caught when getting student details from the api:');
        // eslint-disable-next-line no-console
        console.log(error);
      });
  },
};
</script>
