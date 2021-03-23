import { withRouter } from "react-router";
import React from 'react';
import 'materialize-css';
import { Table, Icon, Button } from 'react-materialize';
import { Link } from "react-router-dom";
import DataService from './DataService'

class MainScreenComponent extends React.Component {

    constructor(props) {
        super(props);
        this.state = {
            users: Array(0),
        }
    }

    componentDidMount() {
        this.refreshUsers();
    }

    refreshUsers() {
        DataService.getAll().then((response) => {
            this.setState({ users: response.data });
        });
    }

    removeUser(id) {
        DataService.delete(id).then(() => {
            this.refreshUsers();
        });
    }

    render() {
        return (
            <Table>
                <thead>
                    <tr>
                        <th>Actions</th>
                        <th data-field="firsname">First Name</th>
                        <th data-field="lastname">Last Name</th>
                        <th data-field="email">Email</th>
                    </tr>
                </thead>
                <tbody>
                    {
                        this.state.users.map(user => (
                            <tr key={user.Id}>
                                <td>
                                    <Link to={`/edituser/${user.Id}`} >
                                        <Button icon={<Icon right>mode_edit</Icon>} flat node="button" waves="light">
                                            Edit
                                        </Button>
                                    </Link>

                                    <Button icon={<Icon right>delete</Icon>}
                                        flat
                                        node="button"
                                        waves="light"
                                        onClick={() => this.removeUser(user.Id)}
                                    >
                                        Delete
                                    </Button>

                                </td>
                                <td>{user.FirstName}</td>
                                <td>{user.LastName}</td>
                                <td>{user.Email}</td>
                            </tr>
                        ))
                    }
                </tbody>
            </Table>
        );
    }
}

export const MainScreen = withRouter(MainScreenComponent)