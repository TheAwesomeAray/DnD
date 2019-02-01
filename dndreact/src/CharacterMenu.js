import React from 'react';
import './bootstrap.min.css';
import './App.css';
import './CharacterMenu.css';
import { connect } from 'react-redux';

const CharacterMenu = connect(mapStateToProps, mapDispatchToProps)(
    function ({characters, characterAdded, onCharacterAdded}) {
    return (
        <div className="body">
        <Menu />
            <div className="side-panel">
                <CharacterList characters={characters} characterAdded={characterAdded} />
            </div>
            <div className="primary-panel">
                <CreateCharacter AddCharacter={onCharacterAdded} />
            </div>
        </div>
    );
});

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

class CreateCharacter extends React.Component {
    constructor(props) {
        super(props);
        this.state = CreateCharacter.initialState(true);
        this.onFieldChange = this.onFieldChange.bind(this);
    }
    static initialState = () => ({
        name: '',
        abilityScores: [
            { name: 'Strength', value: null },
            { name: 'Dexterity', value: null },
            { name: 'Constitution', value: null },
            { name: 'Intelligence', value: null },
            { name: 'Wisdom', value: null },
            { name: 'Charisma', value: null }
        ],
        rollResult: null
    });
    handleSubmit = (event) => {
        event.preventDefault();
        this.props.AddCharacter(this.state);
        this.setState(CreateCharacter.initialState(false));
    };
    onFieldChange(event) {
        this.setState({
            [event.target.name]: event.target.value
        });
    };
    onDieRoll = (result) => {
        this.setState({
            rollResult: result
        });
    };
    onRollAssignment = (abilityName) => {
        this.setState((prevState) => ({
            abilityScores: this.getAbilityScores(abilityName, prevState.abilityScores),
            rollResult: null
        }));
    };
    getAbilityScores = (abilityName, abilityScores) => {
        for (var i = 0; i < abilityScores.length; i++) {
            console.log(i)
            if (abilityScores[i].name === abilityName) {
                abilityScores[i].value = this.state.rollResult
                break;
            }
        }
        return abilityScores;
    };
    render() {
        return (
        <div className="container">
            <form onSubmit={this.handleSubmit}>
                <div className="row">
                    <div className="col-4 text-left">
                        <label className="font-weight-bold">  Character Name</label>
                        <input type="text" className="form-control" 
                            value={this.state.name} name="name"
                            onChange={this.onFieldChange} />
                    </div>
                </div>
                <DieRoll dieSize={20} onDieRoll={this.onDieRoll} />
                <span className="mx-4 font-weight-bold">
                    {this.state.rollResult}
                </span>
                <AbilityScoreList 
                    abilityScores={this.state.abilityScores} 
                    rollResult={this.state.rollResult} 
                    onRollAssignment={this.onRollAssignment}/>
                <Submit />
            </form>
        </div>
        )};
}

const AbilityScoreList = (props) => {
    return (
        <div>
            {props.abilityScores.map((score, i) => 
            <AbilityScore key={i} 
                abilityScore={score} 
                rollResult={props.rollResult}
                onRollAssignment={props.onRollAssignment} />)}
        </div>
    );
}

const AbilityScore = (props) => {
    const handleClick = () => {
        props.onRollAssignment(props.abilityScore.name)
    }
    return (
        <div className="row my-4">
            <div className="col-2 font-weight-bold">
                {props.abilityScore.name}
            </div>
            <div className="col-2">
                {props.abilityScore.value}
                { props.rollResult != null && props.abilityScore.value == null ?
                    <button type="button" className="btn btn-sm btn-warning" onClick={handleClick}>
                        Assign Roll
                    </button> :
                    <div></div>
                }
            </div>
        </div>
    );
}

const DieRoll = (props) => {
    const rollDie = () => {
        props.onDieRoll(1 + Math.floor(Math.random()*props.dieSize));
    }
    return (
        <div className="my-4">
            <button type="button" onClick={rollDie} className="btn btn-info">Roll D{props.dieSize}</button>
        </div>
    );
}

const CharacterList = (props) => {
    return (
        <div className="float-left bg-dark side-panel">
            {props.characters.map((character, i) => 
                <CharacterPanel key={i} character={character} 
                                animationDelay={ props.characterAdded ? "0s" : i*.25 + "s" } />)}
        </div>
    );
}

const CharacterPanel = (props) => {
    return ( 
        <div className="panel bg-light m-2 p-4 character-panel slide" style={{animationDelay: props.animationDelay }}>
            {props.character.name}
        </div>
    );
}

const Submit = (props) => {
    return (
        <div className="text-left my-4">
            <button className="btn btn-primary">Save</button>
        </div>
    );
}

export default CharacterMenu;