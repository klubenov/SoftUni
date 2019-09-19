handlers.getCinema = async function (ctx) {
    ctx.isAuth = userService.isAuth();
    ctx.username = sessionStorage.getItem('username');

    let movies = await movieService.getAllMovies();
   
    if (ctx.params.searchtext){
        let fileterdMovies = [];
        movies.forEach(mov => {
            let genreString = mov.genres.join(' ');
            let searchText = ctx.params.searchtext.slice(1);
            if(genreString.includes(searchText)){
                fileterdMovies.push(mov);
            }
        });
        movies = fileterdMovies;
    }

    ctx.movies = movies;
    
    ctx.movies.sort((a, b) => b.tickets - a.tickets);

    ctx.loadPartials({
        header: '../templates/common/header.hbs',
        footer: '../templates/common/footer.hbs',
        movie: '../templates/movie.hbs'
    }).then(function () {
        this.partial('../../templates/cinema.hbs');
    }).catch(function (err) {
        console.log(err);
    });
}

handlers.getMyMovies = async function (ctx) {
    ctx.isAuth = userService.isAuth();
    ctx.username = sessionStorage.getItem('username');

    ctx.myMovies = await movieService.getMyMovies();
    
    ctx.loadPartials({
        header: '../templates/common/header.hbs',
        footer: '../templates/common/footer.hbs',
        myMovie: '../templates/myMovie.hbs'
    }).then(function () {
        this.partial('../../templates/myMovies.hbs');
    }).catch(function (err) {
        console.log(err);
    });
}

handlers.getAddMovie = function (ctx) {
    ctx.isAuth = userService.isAuth();
    ctx.username = sessionStorage.getItem('username');
    ctx.loadPartials({
        header: '../templates/common/header.hbs',
        footer: '../templates/common/footer.hbs'
    }).then(function () {
        this.partial('../../templates/addMovie.hbs');
    }).catch(function (err) {
        console.log(err);
    });
}

handlers.postAddMovie = function (ctx) {

    let data = { ...ctx.params };

    data.genres = data.genres.split(' ');
    let isGenresValid = true;
    data.genres.forEach(genre => {
        if (genre === '') {
            isGenresValid = false;
        }
    });

    if (data.title.length < 6) {
        notifications.showError('The title should be at least 6 characters long!');
    } else if (data.description.length < 10) {
        notifications.showError('The movie description should be at least 10 characters long!');
    } else if (!data.imageUrl.startsWith('http')) {
        notifications.showError('The image should start with "http://" or "https://"');
    } else if (!isGenresValid) {
        notifications.showError('Genres data must be composed on single genres separated by a single space!');
    } else if (typeof Number(data.tickets) !== 'number') {
        notifications.showError('Available tickets value should be a number!');
    }
    else {
        movieService.createMovie(data).then(function (res) {
            notifications.showSuccess('Movie created successfully!');
            ctx.redirect('#/movies');
        }).catch(function (err) {
            console.log(err);
        })
    }
}

handlers.buyTicket = async function (ctx) {

    let id = ctx.params.id;

    try {
        let movie = await movieService.getMovie(id);

        if (movie.tickets > 0) {
            movie.tickets -= 1;

            movieService.updateMovie(id, movie).then(function () {
                notifications.showSuccess(`Successfully bought ticket for ${movie.title}!`);
                ctx.redirect('#/movies');
            }).catch(function (err) {
                console.log(err);
            })
        } else {
            notifications.showError('No more tickets available!');
            ctx.redirect('#/movies');
        }


    } catch (e) {
        console.log(e);
    }
}

handlers.getMovieDetails = async function (ctx) {
    ctx.isAuth = userService.isAuth();
    ctx.username = sessionStorage.getItem('username');
    let id = ctx.params.id;

    try {
        let movie = await movieService.getMovie(id);
        movie.genres = movie.genres.join(',');
        ctx.movie = movie;
        

        ctx.loadPartials({
            header: '../templates/common/header.hbs',
            footer: '../templates/common/footer.hbs'
        }).then(function () {
            this.partial('../../templates/details.hbs');
        }).catch(function (err) {
            console.log(err);
        });

    } catch (e) {
        console.log(e);
    }
}

handlers.getEditMovie = async function (ctx) {
    ctx.isAuth = userService.isAuth();
    ctx.username = sessionStorage.getItem('username');
    let id = ctx.params.id;

    try {
        let movie = await movieService.getMovie(id);
        movie.genres = movie.genres.join(',');
        ctx.movie = movie;
        

        ctx.loadPartials({
            header: '../templates/common/header.hbs',
            footer: '../templates/common/footer.hbs'
        }).then(function () {
            this.partial('../../templates/edit.hbs');
        }).catch(function (err) {
            console.log(err);
        });

    } catch (e) {
        console.log(e);
    }
}

handlers.postEditMovie = async function (ctx) {

    let id = ctx.params.id;
    
    try {
        if (ctx.params.length < 6) {
            notifications.showError('The title should be at least 6 characters long!');
        } else if (ctx.params.description.length < 10) {
            notifications.showError('The movie description should be at least 10 characters long!');
        } else if (!ctx.params.imageUrl.startsWith('http')) {
            notifications.showError('The image should start with "http://" or "https://"');
        } else if (typeof Number(ctx.params.tickets) !== 'number') {
            notifications.showError('Available tickets value should be a number!');
        }
        else {
            let movie = await movieService.getMovie(id);

            movie.title = ctx.params.title;
            movie.imageUrl = ctx.params.imageUrl;
            movie.description = ctx.params.description;
            movie.genres = ctx.params.genres.split(',');
            movie.tickets = ctx.params.tickets;
            console.log(movie);
            movieService.updateMovie(id, movie).then(function () {
                notifications.showSuccess(`${movie.title} updated successfully!`);
                ctx.redirect('#/movies');
            }).catch(function (err) {
                console.log(err);
            })
        }
    } catch (e) {
        console.log(e);
    }
}

handlers.getDeleteMovie = async function (ctx) {
    ctx.isAuth = userService.isAuth();
    ctx.username = sessionStorage.getItem('username');
    let id = ctx.params.id;

    try {
        let movie = await movieService.getMovie(id);
        movie.genres = movie.genres.join(',');
        ctx.movie = movie;

        ctx.loadPartials({
            header: '../templates/common/header.hbs',
            footer: '../templates/common/footer.hbs'
        }).then(function () {
            this.partial('../../templates/delete.hbs');
        }).catch(function (err) {
            console.log(err);
        });

    } catch (e) {
        console.log(e);
    }
}

handlers.deleteMovie = async function (ctx) {
    let id = ctx.params.id;

    try {
        movieService.deleteMovie(id).then(function () {
            notifications.showSuccess(`Movie removed successfully!`);
            ctx.redirect('#/home');
        }).catch(function (err) {
            console.log(err);
        })
    } catch (e) {
        console.log(e);
    }
}

handlers.searchCinema = function(ctx) {
    
    ctx.redirect(`#/movies/search/${ctx.params.search}`);
}

