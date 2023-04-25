import VueRouter from 'vue-router';
import StudentIndex from '../components/Student/Index.vue';
import StudentStatusesIndex from '../components/StudentStatus/Index.vue';
import StudentCreate from '../components/Student/Create.vue';
import StudentDetail from '../components/Student/Detail.vue';
import CourseIndex from '../components/Course/Index.vue';
import CourseCreate from '../components/Course/Create.vue';
import CourseDetail from '../components/Course/Detail.vue';

const routes = [
  {
    path: '/students',
    name: 'default',
    component: StudentIndex,
  },
  {
    path: '/statuses',
    name: 'student_statuses',
    component: StudentStatusesIndex,
  },
  {
    path: '/students/create',
    name: 'student_create',
    component: StudentCreate,
  },
  {
    path: '/students/:id',
    name: 'Student',
    component: StudentDetail,
  },
  {
    path: '/students/:id/edit',
    name: 'EditStudent',
    component: StudentCreate,
  },
  {
    path: '/courses',
    name: 'default',
    component: CourseIndex,
  },
  {
    path: '/courses/create',
    name: 'course_create',
    component: CourseCreate,
  },
  {
    path: '/courses/:id',
    name: 'Course',
    component: CourseDetail,
  },
  {
    path: '/courses/:id/edit',
    name: 'EditCourse',
    component: CourseCreate,
  },
];

export default new VueRouter({
  mode: 'history',
  routes,
  linkActiveClass: 'is-active', // apply bulma class when a router link is active
});
