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
    characters: initialCharacters(),
    characterAdded: false
  }
  AddCharacter = (character) => {
    this.setState((prevState) => ({
      characters: prevState.characters.concat([character]),
      characterAdded: true
    }));
    
  };
  render() {
    return (
      <div className="App">
        <CharacterMenu {...this.state} 
                       AddCharacter={this.AddCharacter} />
      </div>
    );
  }
}

export default App;
