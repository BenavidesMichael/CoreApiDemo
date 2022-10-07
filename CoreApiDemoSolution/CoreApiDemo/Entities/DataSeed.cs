using Microsoft.EntityFrameworkCore;
using NetTopologySuite;
using NetTopologySuite.Geometries;

namespace CoreApiDemo.Entities
{
    public static class DataSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var acción = new Genre { Id = 1, Name = "Acción" };
            var animación = new Genre { Id = 2, Name = "Animación" };
            var comedia = new Genre { Id = 3, Name = "Comedia" };
            var cienciaFicción = new Genre { Id = 4, Name = "Ciencia ficción" };
            var drama = new Genre { Id = 5, Name = "Drama" };

            modelBuilder.Entity<Genre>().HasData(acción, animación, comedia, cienciaFicción, drama);

            var tomHolland = new Actor() { Id = 1, Name = "Tom Holland", Birthdate = new DateTime(1996, 6, 1), Biography = "Thomas Stanley Holland (Kingston upon Thames, Londres; 1 de junio de 1996), conocido simplemente como Tom Holland, es un actor, actor de voz y bailarín británico." };
            var samuelJackson = new Actor() { Id = 2, Name = "Samuel L. Jackson", Birthdate = new DateTime(1948, 12, 21), Biography = "Samuel Leroy Jackson (Washington D. C., 21 de diciembre de 1948), conocido como Samuel L. Jackson, es un actor y productor de Theater, televisión y teatro estadounidense. Ha sido candidato al premio Óscar, a los Globos de Oro y al Premio del Sindicato de Actores, así como ganador de un BAFTA al mejor actor de reparto." };
            var robertDowney = new Actor() { Id = 3, Name = "Robert Downey Jr.", Birthdate = new DateTime(1965, 4, 4), Biography = "Robert John Downey Jr. (Nueva York, 4 de abril de 1965) es un actor, actor de voz, productor y cantante estadounidense. Inició su carrera como actor a temprana edad apareciendo en varios filmes dirigidos por su padre, Robert Downey Sr., y en su infancia estudió actuación en varias academias de Nueva York." };
            var chrisEvans = new Actor() { Id = 4, Name = "Chris Evans", Birthdate = new DateTime(1981, 06, 13) };
            var laRoca = new Actor() { Id = 5, Name = "Dwayne Johnson", Birthdate = new DateTime(1972, 5, 2) };
            var auliCravalho = new Actor() { Id = 6, Name = "Auli'i Cravalho", Birthdate = new DateTime(2000, 11, 22) };
            var scarlettJohansson = new Actor() { Id = 7, Name = "Scarlett Johansson", Birthdate = new DateTime(1984, 11, 22) };
            var keanuReeves = new Actor() { Id = 8, Name = "Keanu Reeves", Birthdate = new DateTime(1964, 9, 2) };

            modelBuilder.Entity<Actor>().HasData(tomHolland, samuelJackson,
                            robertDowney, chrisEvans, laRoca, auliCravalho, scarlettJohansson, keanuReeves);
            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);

            var agora = new Theater() { Id = 1, Name = "Agora Mall", Location = geometryFactory.CreatePoint(new Coordinate(-69.9388777, 18.4839233)) };
            var sambil = new Theater() { Id = 2, Name = "Sambil", Location = geometryFactory.CreatePoint(new Coordinate(-69.911582, 18.482455)) };
            var megacentro = new Theater() { Id = 3, Name = "Megacentro", Location = geometryFactory.CreatePoint(new Coordinate(-69.856309, 18.506662)) };
            var acropolis = new Theater() { Id = 4, Name = "Acropolis", Location = geometryFactory.CreatePoint(new Coordinate(-69.939248, 18.469649)) };

            var agoraTheaterOffer = new TheaterOffer { Id = 1, TheaterId = agora.Id, BeginDate = DateTime.Today, EndDate = DateTime.Today.AddDays(7), Discount = 10 };

            var RoomTheatre2DAgora = new RoomTheatre()
            {
                Id = 1,
                TheaterId = agora.Id,
                Price = 220,
                TypeRoomTheatre = TypeRoomTheatre.DeuxD
            };
            var RoomTheatre3DAgora = new RoomTheatre()
            {
                Id = 2,
                TheaterId = agora.Id,
                Price = 320,
                TypeRoomTheatre = TypeRoomTheatre.TroisD
            };

            var RoomTheatre2DSambil = new RoomTheatre()
            {
                Id = 3,
                TheaterId = sambil.Id,
                Price = 200,
                TypeRoomTheatre = TypeRoomTheatre.DeuxD
            };
            var RoomTheatre3DSambil = new RoomTheatre()
            {
                Id = 4,
                TheaterId = sambil.Id,
                Price = 290,
                TypeRoomTheatre = TypeRoomTheatre.TroisD
            };


            var RoomTheatre2DMegacentro = new RoomTheatre()
            {
                Id = 5,
                TheaterId = megacentro.Id,
                Price = 250,
                TypeRoomTheatre = TypeRoomTheatre.DeuxD
            };
            var RoomTheatre3DMegacentro = new RoomTheatre()
            {
                Id = 6,
                TheaterId = megacentro.Id,
                Price = 330,
                TypeRoomTheatre = TypeRoomTheatre.TroisD
            };
            var RoomTheatreImaxMegacentro = new RoomTheatre()
            {
                Id = 7,
                TheaterId = megacentro.Id,
                Price = 450,
                TypeRoomTheatre = TypeRoomTheatre.Imax
            };

            var RoomTheatre2DAcropolis = new RoomTheatre()
            {
                Id = 8,
                TheaterId = acropolis.Id,
                Price = 250,
                TypeRoomTheatre = TypeRoomTheatre.DeuxD
            };

            var acropolisTheaterOffer = new TheaterOffer { Id = 2, TheaterId = acropolis.Id, BeginDate = DateTime.Today, EndDate = DateTime.Today.AddDays(5), Discount = 15 };

            modelBuilder.Entity<Theater>().HasData(acropolis, sambil, megacentro, agora);
            modelBuilder.Entity<TheaterOffer>().HasData(acropolisTheaterOffer, agoraTheaterOffer);
            modelBuilder.Entity<RoomTheatre>().HasData(RoomTheatre2DMegacentro, RoomTheatre3DMegacentro, RoomTheatreImaxMegacentro, RoomTheatre2DAcropolis, RoomTheatre2DAgora, RoomTheatre3DAgora, RoomTheatre2DSambil, RoomTheatre3DSambil);


            var avengers = new Movie()
            {
                Id = 1,
                Title = "Avengers",
                IsAvailable = false,
                ReleaseDate = new DateTime(2012, 4, 11),
                UrlImage = "https://upload.wikimedia.org/wikipedia/en/8/8a/The_Avengers_%282012_film%29_poster.jpg",
            };

            var entidadGenreMovie = "GenreMovie";
            var GenreIdPropiedad = "GenresId";
            var MovieIdPropiedad = "MoviesId";

            var entidadRoomTheatreMovie = "MovieRoomTheatre";
            var RoomTheatreIdPropiedad = "RoomTheatresId";

            modelBuilder.Entity(entidadGenreMovie).HasData(
                new Dictionary<string, object> { [GenreIdPropiedad] = acción.Id, [MovieIdPropiedad] = avengers.Id },
                new Dictionary<string, object> { [GenreIdPropiedad] = cienciaFicción.Id, [MovieIdPropiedad] = avengers.Id }
            );

            var coco = new Movie()
            {
                Id = 2,
                Title = "Coco",
                IsAvailable = false,
                ReleaseDate = new DateTime(2017, 11, 22),
                UrlImage = "https://upload.wikimedia.org/wikipedia/en/9/98/Coco_%282017_film%29_poster.jpg"
            };

            modelBuilder.Entity(entidadGenreMovie).HasData(
               new Dictionary<string, object> { [GenreIdPropiedad] = animación.Id, [MovieIdPropiedad] = coco.Id }
           );

            var noWayHome = new Movie()
            {
                Id = 3,
                Title = "Spider-Man: No way home",
                IsAvailable = false,
                ReleaseDate = new DateTime(2021, 12, 17),
                UrlImage = "https://upload.wikimedia.org/wikipedia/en/0/00/Spider-Man_No_Way_Home_poster.jpg"
            };

            modelBuilder.Entity(entidadGenreMovie).HasData(
               new Dictionary<string, object> { [GenreIdPropiedad] = cienciaFicción.Id, [MovieIdPropiedad] = noWayHome.Id },
               new Dictionary<string, object> { [GenreIdPropiedad] = acción.Id, [MovieIdPropiedad] = noWayHome.Id },
               new Dictionary<string, object> { [GenreIdPropiedad] = comedia.Id, [MovieIdPropiedad] = noWayHome.Id }
           );

            var farFromHome = new Movie()
            {
                Id = 4,
                Title = "Spider-Man: Far From Home",
                IsAvailable = false,
                ReleaseDate = new DateTime(2019, 7, 2),
                UrlImage = "https://upload.wikimedia.org/wikipedia/en/0/00/Spider-Man_No_Way_Home_poster.jpg"
            };

            modelBuilder.Entity(entidadGenreMovie).HasData(
               new Dictionary<string, object> { [GenreIdPropiedad] = cienciaFicción.Id, [MovieIdPropiedad] = farFromHome.Id },
               new Dictionary<string, object> { [GenreIdPropiedad] = acción.Id, [MovieIdPropiedad] = farFromHome.Id },
               new Dictionary<string, object> { [GenreIdPropiedad] = comedia.Id, [MovieIdPropiedad] = farFromHome.Id }
           );

            // Para matrix pongo la fecha en el futuro

            var theMatrixResurrections = new Movie()
            {
                Id = 5,
                Title = "The Matrix Resurrections",
                IsAvailable = true,
                ReleaseDate = new DateTime(2100, 1, 1),
                UrlImage = "https://upload.wikimedia.org/wikipedia/en/5/50/The_Matrix_Resurrections.jpg",
            };

            modelBuilder.Entity(entidadGenreMovie).HasData(
              new Dictionary<string, object> { [GenreIdPropiedad] = cienciaFicción.Id, [MovieIdPropiedad] = theMatrixResurrections.Id },
              new Dictionary<string, object> { [GenreIdPropiedad] = acción.Id, [MovieIdPropiedad] = theMatrixResurrections.Id },
              new Dictionary<string, object> { [GenreIdPropiedad] = drama.Id, [MovieIdPropiedad] = theMatrixResurrections.Id }
          );

            modelBuilder.Entity(entidadRoomTheatreMovie).HasData(
             new Dictionary<string, object> { [RoomTheatreIdPropiedad] = RoomTheatre2DSambil.Id, [MovieIdPropiedad] = theMatrixResurrections.Id },
             new Dictionary<string, object> { [RoomTheatreIdPropiedad] = RoomTheatre3DSambil.Id, [MovieIdPropiedad] = theMatrixResurrections.Id },
             new Dictionary<string, object> { [RoomTheatreIdPropiedad] = RoomTheatre2DAgora.Id, [MovieIdPropiedad] = theMatrixResurrections.Id },
             new Dictionary<string, object> { [RoomTheatreIdPropiedad] = RoomTheatre3DAgora.Id, [MovieIdPropiedad] = theMatrixResurrections.Id },
             new Dictionary<string, object> { [RoomTheatreIdPropiedad] = RoomTheatre2DMegacentro.Id, [MovieIdPropiedad] = theMatrixResurrections.Id },
             new Dictionary<string, object> { [RoomTheatreIdPropiedad] = RoomTheatre3DMegacentro.Id, [MovieIdPropiedad] = theMatrixResurrections.Id },
             new Dictionary<string, object> { [RoomTheatreIdPropiedad] = RoomTheatreImaxMegacentro.Id, [MovieIdPropiedad] = theMatrixResurrections.Id }
         );


            var keanuReevesMatrix = new ActorMovie
            {
                ActorId = keanuReeves.Id,
                MovieId = theMatrixResurrections.Id,
                Order = 1,
                Character = "Neo"
            };

            var avengersChrisEvans = new ActorMovie
            {
                ActorId = chrisEvans.Id,
                MovieId = avengers.Id,
                Order = 1,
                Character = "Capitán América"
            };

            var avengersRobertDowney = new ActorMovie
            {
                ActorId = robertDowney.Id,
                MovieId = avengers.Id,
                Order = 2,
                Character = "Iron Man"
            };

            var avengersScarlettJohansson = new ActorMovie
            {
                ActorId = scarlettJohansson.Id,
                MovieId = avengers.Id,
                Order = 3,
                Character = "Black Widow"
            };

            var tomHollandFFH = new ActorMovie
            {
                ActorId = tomHolland.Id,
                MovieId = farFromHome.Id,
                Order = 1,
                Character = "Peter Parker"
            };

            var tomHollandNWH = new ActorMovie
            {
                ActorId = tomHolland.Id,
                MovieId = noWayHome.Id,
                Order = 1,
                Character = "Peter Parker"
            };

            var samuelJacksonFFH = new ActorMovie
            {
                ActorId = samuelJackson.Id,
                MovieId = farFromHome.Id,
                Order = 2,
                Character = "Samuel L. Jackson"
            };

            modelBuilder.Entity<Movie>().HasData(avengers, coco, noWayHome, farFromHome, theMatrixResurrections);
            modelBuilder.Entity<ActorMovie>().HasData(samuelJacksonFFH, tomHollandFFH, tomHollandNWH, avengersRobertDowney, avengersScarlettJohansson,
                avengersChrisEvans, keanuReevesMatrix);

        }
    }
}