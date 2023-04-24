<template>
  <div class="container">
    <nav class="navbar" role="navigation" aria-label="main navigation">
      <div id="navbarBasicExample"
           :class="`navbar-menu ${menuActive ? 'is-active' : ''}`">
        <div class="navbar-start">
          <router-link to="/students" class="nav-item">
            <span class="icon has-text-primary">
              <icon icon="address-book"></icon>
            </span>
            <span>Students</span>
          </router-link>
            <router-link to="/statuses" class="nav-item">
            <span class="icon has-text-primary">
              <icon icon="check-circle"></icon>
            </span>
                <span>Statuses</span>
            </router-link>
        </div>

      </div>
    </nav>
    <main>
      <transition name="fade" mode="out-in">
        <slot></slot>
      </transition>
    </main>
  </div>
</template>

<script>
export default {
  data() {
    return {
      menuActive: false,
    };
  },
};
</script>

<style lang="scss" scoped>
@import "~bulma/sass/utilities/mixins";

@media screen and (min-width: $widescreen) {
  .navbar {
    font-size: 1.125rem;
    padding: 2rem 0;
  }
}

@media screen and (min-width: $desktop) {
  .navbar {
    padding: 1rem 0;
  }
}

.navbar-item > .icon {
  margin-left: -0.25rem;
  margin-right: 0.25rem;
}

.fade-enter-active, .fade-leave-active {
  transition: opacity .25s
}

.fade-enter, .fade-leave-to {
  opacity: 0
}
</style>
