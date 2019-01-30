import React from 'react';
import './bootstrap.min.css';


const MainMenu = () => {
    return (
        <div style={{paddingTop: '25px'}}>
            <CreateButton />
        </div>
    );
}

export default MainMenu;


const CreateButton = (props) => {
    return (
        <div>
            <button className="btn btn-success">Create Character</button>
        </div>
    );
}