import React, { Component } from 'react';
import './App.css';
import CharacterMenu from './CharacterMenu';
import { connect } from 'react-redux';

let state;
const App = connect(mapStateToProps, mapDispatchToProps)(
  function ({characters, characterAdded, onCharacterAdded}) {
    console.log(characterAdded);
  return (
    <div className="App">
      <Menu />
      <CharacterMenu  characterAdded={characterAdded}
                      characters={characters}
                      AddCharacter={onCharacterAdded} />
    </div>
  );
});

const Menu = () => {
  return (
    <nav className="navbar navbar-expand-lg navbar-dark bg-dark">
      <a className="navbar-brand" href="#">Dungeons and Dragons</a>
     <button className="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
        <span className="navbar-toggler-icon"></span>
      </button>
      <div className="collapse navbar-collapse" id="navbarSupportedContent">
        <ul className="navbar-nav mr-auto">
          <li className="nav-item active">
            <a className="nav-link" href="/">Character Creation <span class="sr-only">(current)</span></a>
          </li>
          <li className="nav-item">
            <a className="nav-link" href="/StoryMode">Story Mode</a>
          </li>
        </ul>
  </div>
  
  </nav>
  );
}

function mapStateToProps(state) {
  return {
    characters: state.characters,
    characterAdded: state.characterAdded
  }
}

function mapDispatchToProps(dispatch) {
  return {
    onCharacterAdded: (character) => {
      dispatch({type: 'CHARACTER_ADDED', character})
    }
  }
}

export default App;