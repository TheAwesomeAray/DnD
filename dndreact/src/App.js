import React, { Component } from 'react';
import './App.css';
import MainMenu from './MainMenu';
import CharacterMenu from './CharacterMenu';

function initialCharacters() {
  return [
  { name: 'Ilin' },
  { name: 'Kagor' },
  { name: 'Bellocke' }]
};

class App extends Component {
  state = {
    characters: initialCharacters()
  }
  AddCharacter = (character) => {
    this.setState((prevState) => ({
      characters: prevState.characters.concat([character])
    }));
    
  };
  render() {
    return (
      <div className="App">
        <CharacterMenu characters={this.state.characters} AddCharacter={this.AddCharacter} />
      </div>
    );
  }
}

export default App;
