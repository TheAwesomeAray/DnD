import React from 'react';
import './bootstrap.min.css';
import './App.css';
import { connect } from 'react-redux';

const StoryMode = connect(mapStateToProps, mapDispatchToProps)(
    function ({characters}) {
    return (
        <div className="body">
            <Menu />
            <Initiative characters={characters} />
        </div>
    );
});

function mapStateToProps(state) {
    return {
      characters: state.characters
    }
  }
  
  function mapDispatchToProps(dispatch) {
    return;
  }

const Menu = () => {
    return (
      <nav className="navbar navbar-expand-lg navbar-dark bg-dark">
        <a className="navbar-brand" href="/">Dungeons and Dragons</a>
       <button className="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
          <span className="navbar-toggler-icon"></span>
        </button>
        <div className="collapse navbar-collapse" id="navbarSupportedContent">
          <ul className="navbar-nav mr-auto">
            <li className="nav-item active">
              <a className="nav-link" href="/">Character Creation <span className="sr-only">(current)</span></a>
            </li>
            <li className="nav-item">
              <a className="nav-link" href="/StoryMode">Story Mode</a>
            </li>
          </ul>
    </div>
    </nav>
    );
  }

  const Initiative = (props) => {
    const rollInitiative = () => {
        for (var i = 0; i < props.characters.length; i++) {
            console.log(props.characters[i].abilityScores.find(obj => { return obj.name === 'Dexterity'}));
        }
    }
    return (
        <div className="my-4">
            <button type="button" onClick={rollInitiative} className="btn btn-info">Roll Initiave!</button>
        </div>
    );
}

export default StoryMode;
