const handlers = {}

$(() => {
  const app = Sammy('#container', function () {
    this.use('Handlebars', 'hbs');
    // home page routes
    this.get('/index.html', handlers.getHome);
    this.get('/', handlers.getHome);
    this.get('#/home', handlers.getHome);

    // user routes
    this.get('#/register', handlers.getRegister);
    this.get('#/login', handlers.getLogin);

    this.post('#/register', handlers.registerUser);
    this.post('#/login', handlers.loginUser);
    this.get('#/logout', handlers.logoutUser);

    // ADD YOUR ROUTES HERE
    this.get('#/movies/search(/:searchtext)?', handlers.getCinema);
    this.get('#/movies', handlers.getCinema);
    this.post('#/search', handlers.searchCinema);
    this.get('#/myMovies', handlers.getMyMovies);
    this.get('#/movies/edit/:id', handlers.getEditMovie);
    this.get('#/editMovie/:id', handlers.postEditMovie);
    this.get('#/movies/create', handlers.getAddMovie);
    this.post('#/addMovie', handlers.postAddMovie);
    this.get('#/movies/delete/:id', handlers.getDeleteMovie);
    this.get('#/deleteMovie/:id', handlers.deleteMovie);
    this.get('#/buyTicket/:id', handlers.buyTicket);
    this.get('#/movies/details/:id', handlers.getMovieDetails)
  });
  app.run('#/home');
});