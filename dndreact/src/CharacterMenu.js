import React from 'react';
import './bootstrap.min.css';
import './App.css'


const CharacterMenu = (props) => {
    return (
        <div className="body">
            <div className="side-panel">
                <CharacterList characters={props.characters} />
            </div>
            <div className="primary-panel">
                <CreateCharacter AddCharacter={props.AddCharacter} />
            </div>
        </div>
    );
}

class CreateCharacter extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
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
        };
        this.onFieldChange = this.onFieldChange.bind(this);
    }
    handleSubmit = (event) => {
        event.preventDefault();
        this.props.AddCharacter(this.state);
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
        console.log(abilityScores);
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
            {props.characters.map((character, i) => <CharacterPanel key={i} character={character} />)}
        </div>
    );
}

const CharacterPanel = (props) => {
    return (
        <div className="panel bg-light m-2 p-4 character-panel">
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