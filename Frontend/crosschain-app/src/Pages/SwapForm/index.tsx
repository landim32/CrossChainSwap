import Container from 'react-bootstrap/Container';
import Button from 'react-bootstrap/Button';
import Card from 'react-bootstrap/Card';
import Col from 'react-bootstrap/Col';
import Form from 'react-bootstrap/Form';
import Row from 'react-bootstrap/Row';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faRetweet } from '@fortawesome/free-solid-svg-icons/faRetweet'
import { useContext } from 'react';
import AuthContext from '../../Contexts/Auth/AuthContext';

export default function SwapForm() {
    const authContext = useContext(AuthContext);

    return (
        <Container>
            <Row>
                <Col md="8" className='offset-md-2'>
                    <Card>
                        <Card.Body>
                            <h1 className="text-center">BTC to STX</h1>
                            <Card className="mb-3">
                                <Card.Body>
                                    <Row>
                                        <Col md="6">
                                            <Form.Group as={Col} controlId="OrigAmount">
                                                <Form.Label>From</Form.Label>
                                                <Form.Select aria-label="Default select example">
                                                    <option selected value="bitcoin">Bitcoin</option>
                                                    <option value="stacks">Stacks</option>
                                                </Form.Select>
                                                <Form.Text id="passwordHelpBlock" muted>
                                                    Price: ~
                                                </Form.Text>
                                            </Form.Group>
                                        </Col>
                                        <Col md="6">
                                            <Form.Label htmlFor="inputPassword5">Amount:</Form.Label>
                                            <Form.Group as={Col} controlId="OrigAmount">
                                                <Form.Control
                                                    type="number"
                                                    step="0.1"
                                                    style={{textAlign: 'right'}}
                                                    id="origAmount"
                                                    aria-describedby="passwordHelpBlock"
                                                />
                                                <Form.Text id="passwordHelpBlock" muted>
                                                    Pool Balance ~
                                                </Form.Text>
                                            </Form.Group>
                                        </Col>
                                    </Row>
                                </Card.Body>
                            </Card>
                            <Row className="mb-3">
                                <Col md="2" className='offset-md-5'>
                                    <view className='d-grid gap-2'>
                                    <Button size="lg" variant="warning">
                                        <FontAwesomeIcon icon={faRetweet} />
                                    </Button>
                                    </view>
                                </Col>
                            </Row>
                            <Card className="mb-3">
                                <Card.Body>
                                    <Row>
                                        <Col md="6">
                                            <Form.Group as={Col} controlId="DestAmount">
                                                <Form.Label>To</Form.Label>
                                                <Form.Select aria-label="Default select example">
                                                    <option value="bitcoin">Bitcoin</option>
                                                    <option selected value="stacks">Stacks</option>
                                                </Form.Select>
                                                <Form.Text id="passwordHelpBlock" muted>
                                                    Price: ~
                                                </Form.Text>
                                            </Form.Group>
                                        </Col>
                                        <Col md="6">
                                            <Form.Label htmlFor="inputPassword5">Amount:</Form.Label>
                                            <Form.Group as={Col} controlId="OrigAmount">
                                                <Form.Control
                                                    type="text"
                                                    id="destAmount"
                                                    readOnly={true}
                                                    style={{textAlign: 'right'}}
                                                    aria-describedby="passwordHelpBlock"
                                                />
                                                <Form.Text id="passwordHelpBlock" muted>
                                                    Pool Balance ~
                                                </Form.Text>
                                            </Form.Group>
                                        </Col>
                                    </Row>
                                </Card.Body>
                            </Card>
                            <p className="mb-3" style={{textAlign: 'center'}}>1 STX = 0,003435 BTC</p>
                            <Row>
                                <Col md="4" className='offset-md-4'>
                                    <view className='d-grid gap-2'>
                                    <Button size="lg" variant="primary">
                                        <FontAwesomeIcon icon={faRetweet} /> Swap
                                    </Button>
                                    </view>
                                </Col>
                            </Row>
                        </Card.Body>
                    </Card>
                </Col>
            </Row>
        </Container>
    );
}