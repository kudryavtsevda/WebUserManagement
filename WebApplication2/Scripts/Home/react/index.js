import React from 'react';
import { render } from 'react-dom';
import axios from "axios";
import 'materialize-css';
import { Button, Icon } from 'react-materialize';
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
                            <Link to="/">
                                <Button icon={<Icon right>list</Icon>} flat node="button" waves="light">
                                    Get all users
                                 </Button></Link>
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
                            <div>CREATE USER</div>
                        </Route>
                        <Route path="/edituser/:id">
                            <EditUser />
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