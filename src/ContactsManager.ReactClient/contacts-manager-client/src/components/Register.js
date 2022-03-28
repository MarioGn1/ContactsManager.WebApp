import { NavLink } from 'react-router-dom';

const Register = () => {
    return (
        <>
            <section id="register-page" className="content auth">
                <form id="register">
                    <div className="container">
                        <h1>Register</h1>

                        <label htmlFor="email">Email:</label>
                        <input type="email" id="email" name="email" placeholder="maria@email.com" />

                        <label htmlFor="pass">Password:</label>
                        <input type="password" name="password" id="register-password" />

                        <label htmlFor="con-pass">Confirm Password:</label>
                        <input type="password" name="confirm-password" id="confirm-password" />

                        <input className="btn submit" type="submit" value="Register" />


                    </div>
                </form>
            </section>
            <p className="field">
                <span>If you already have profile click <NavLink activeClassName="active-navigation-link" to="/login">here.</NavLink></span>
            </p>
        </>

    );
}

export default Register;