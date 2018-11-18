import os
import glob
import hdf5_getters
import csv


class SongInfo:

    def __init__(self):
        self.song_id = 0
        self.title = 0
        self.album_name = 0
        self.artist_id = 0


class SongAnalysis:

    def __init__(self):
        self.song_id = 0
        self.song_hotness = 0.0
        self.tempo = 0.0
        self.duration = 0.0
        self.loudness = 0.0


class Artist:

    def __init__(self):
        self.artist_id = 0
        self.artist_name = 0
        self.genre = 0
        self.artist_hotness = 0.0


def generate_song_info_from_file(h5_file):
    song_info = SongInfo()
    # song_info.song_id = hdf5_getters.get_song_id(h5_file)
    song_info.title = hdf5_getters.get_title(h5_file)
    song_info.album_name = hdf5_getters.get_release(h5_file)
    # song_info.artist_id = hdf5_getters.get_artist_id(h5_file)
    return song_info


def generate_song_analysis_from_file(h5_file):
    song_analysis = SongAnalysis()
    # song_analysis.song_id = hdf5_getters.get_song_id(h5_file)
    song_analysis.song_hotness = hdf5_getters.get_song_hotttnesss(h5_file)
    if str(song_analysis.song_hotness) == 'nan':
        # TODO: NULL?
        song_analysis.song_hotness = 0.0
    song_analysis.tempo = hdf5_getters.get_tempo(h5_file)
    song_analysis.duration = hdf5_getters.get_duration(h5_file)
    song_analysis.loudness = hdf5_getters.get_loudness(h5_file)
    return song_analysis


def generate_artist_from_file(h5_file):
    artist = Artist()
    # artist.artist_id = hdf5_getters.get_artist_id(h5_file)
    artist.artist_name = hdf5_getters.get_artist_name(h5_file)
    genres = hdf5_getters.get_artist_terms(h5_file)
    if len(genres) > 0:
        artist.genre = genres[0]
    else:
        artist.genre = None
    artist.artist_hotness = hdf5_getters.get_artist_hotttnesss(h5_file)
    return artist


# generate csv writers
song_info_csv = open('song_info.csv', 'wb')
song_info_writer = csv.writer(song_info_csv, delimiter=',', quotechar='"', quoting=csv.QUOTE_MINIMAL)
song_analysis_csv = open('song_analysis.csv', 'wb')
song_analysis_writer = csv.writer(song_analysis_csv, delimiter=',', quotechar='"', quoting=csv.QUOTE_MINIMAL)
artists_csv = open('artists.csv', 'wb')
artists_writer = csv.writer(artists_csv, delimiter=',', quotechar='"', quoting=csv.QUOTE_MINIMAL)

# write first row
song_info_writer.writerow(['song_id', 'title', 'album_name', 'artist_id'])
song_analysis_writer.writerow(['song_id', 'song_hotness', 'tempo', 'duration', 'loudness'])
artists_writer.writerow(['artist_id', 'artist_name', 'genre', 'artist_hotness'])

# generate data from h5 files
# TODO: Similar Artists
artist_id = 1
song_id = 1
basedir = "D:\MillionSongSubset\data"  # TODO: hardcoded as fuck
ext = ".h5"
for root, dirs, files in os.walk(basedir):
    fs = glob.glob(os.path.join(root, '*' + ext))
    for f in fs:
        songH5File = hdf5_getters.open_h5_file_read(f)
        song_info = generate_song_info_from_file(songH5File)
        song_analysis = generate_song_analysis_from_file(songH5File)
        artist = generate_artist_from_file(songH5File)

        # ids
        song_info.song_id = song_id
        song_info.artist_id = artist_id
        song_analysis.song_id = song_id
        artist.artist_id = artist_id
        artist_id += 1
        song_id += 1

        # rows
        song_info_row = [song_info.song_id, song_info.title, song_info.album_name, song_info.artist_id]
        song_analysis_row = [song_analysis.song_id, song_analysis.song_hotness, song_analysis.tempo,
                             song_analysis.duration, song_analysis.loudness]
        artist_row = [artist.artist_id, artist.artist_name, artist.genre, artist.artist_hotness]

        # write row to file
        song_info_writer.writerow(song_info_row)
        song_analysis_writer.writerow(song_analysis_row)
        artists_writer.writerow(artist_row)

        songH5File.close()
song_info_csv.close()
song_analysis_csv.close()
artists_csv.close()
