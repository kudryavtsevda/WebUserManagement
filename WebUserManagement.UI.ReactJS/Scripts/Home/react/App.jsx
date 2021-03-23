import React from 'react';
import 'materialize-css';
import { Button, Icon } from 'react-materialize';
import { MainScreen } from './MainScreen.jsx';
import { EditUser } from './EditUser.jsx';
import { AddUser } from './AddUser.jsx';
import {
    BrowserRouter as Router,
    Switch,
    Route,
    Link
} from "react-router-dom";

export function App(props) {
    return (
        <Router>
            <div>
                <ul>
                    <li>
                        <Link to="/">
                            <Button icon={<Icon right>list</Icon>} flat node="button" waves="light">
                                Get all users
                                 </Button>
                        </Link>
                    </li>
                    <li>
                        <Link to="/createuser">
                            <Button icon={<Icon right>person_add</Icon>} flat node="button" waves="light">
                                Add user
                                 </Button>
                        </Link>
                    </li>
                </ul>
                <hr />
                <Switch>
                    <Route exact path="/">
                        <MainScreen />
                    </Route>
                    <Route path="/createuser">
                        <AddUser />
                    </Route>
                    <Route path="/edituser/:id">
                        <EditUser />
                    </Route>
                </Switch>
            </div>
        </Router>
    )
}