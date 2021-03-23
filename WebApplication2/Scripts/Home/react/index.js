import React from 'react';
import { render } from 'react-dom';
import axios from "axios";
import 'materialize-css';
import { Table } from 'react-materialize';
import { MainScreen } from './MainScreen.jsx';
import { EditUser } from './EditUser.jsx';
import {
    BrowserRouter as Router,
    Switch,
    Route,
    Link
} from "react-router-dom";


class App extends React.Component {

    render() {
        return (
            <Router>
                <div>
                    <ul>
                        <li>
                            <Link to="/">Main screen</Link>
                        </li>
                        <li>
                            <Link to="/createuser">CREATE USER</Link>
                        </li>                        
                    </ul>

                    <hr />

                    {/*
          A <Switch> looks through all its children <Route>
          elements and renders the first one whose path
          matches the current URL. Use a <Switch> any time
          you have multiple routes, but you want only one
          of them to render at a time
        */}
                    <Switch>
                        <Route exact path="/">
                            <MainScreen />
                        </Route>
                        <Route path="/createuser">
                            <div>CREATE USER</div>
                        </Route>
                        <Route path="/edituser/:id">
                            <EditUser/>
                        </Route>
                    </Switch>
                </div>
            </Router>
            )
    }
}

render(
    <App />,
    document.getElementById("app")
);