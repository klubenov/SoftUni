const movieService = (() => {
    function createMovie (data) {
        return kinvey.post('appdata', 'movies', 'kinvey', data);
    }

    function getAllMovies () {
        return kinvey.get('appdata', 'movies', 'kinvey');
    }

    function getMyMovies () {
        return kinvey.get('appdata', 'movies', 'kinvey', `?query={"_acl.creator":"${sessionStorage.getItem('id')}"}`);
    }

    function updateMovie (id, movie) {
        return kinvey.update('appdata', `movies/${id}`, 'kinvey', movie);
    }

    function getMovie(id) {
        return kinvey.get('appdata', `movies/${id}`, 'kinvey');
    }

    function deleteMovie(id) {
        return kinvey.remove('appdata', `movies/${id}`, 'kinvey');
    }

    return {
        createMovie,
        getAllMovies,
        updateMovie,
        getMovie,
        getMyMovies,
        deleteMovie
    }
})()