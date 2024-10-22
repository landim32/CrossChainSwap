import Container from 'react-bootstrap/Container';
import Button from 'react-bootstrap/Button';
import Card from 'react-bootstrap/Card';
import Col from 'react-bootstrap/Col';
import Form from 'react-bootstrap/Form';
import Row from 'react-bootstrap/Row';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faRetweet } from '@fortawesome/free-solid-svg-icons/faRetweet'
import { useContext, useEffect } from 'react';
import AuthContext from '../../Contexts/Auth/AuthContext';
import SwapContext from '../../Contexts/Swap/SwapContext';
import { CoinEnum } from '../../DTO/Enum/CoinEnum';
import SwapModal from '../../Components/SwapModal';

export default function SwapForm() {
    const swapContext = useContext(SwapContext);
    useEffect(() => {
        swapContext.loadPoolInfo();
        swapContext.loadCurrentPrice();
    }, []);

    return (
        <Container>
            <Row>
                <Col md="6" className='offset-md-3'>
                    <Card>
                        <Card.Body>
                            <h1 className="text-center">BTC to STX</h1>
                            <Card className="mb-3">
                                <Card.Body>
                                    <Row>
                                        <Col md="6">
                                            <Form.Group as={Col} controlId="OrigAmount">
                                                <Form.Label>From</Form.Label>
                                                <Form.Select value={swapContext.origCoin} onChange={(e) => {
                                                    if (e.target.value == '1') {
                                                        swapContext.setOrigCoin(CoinEnum.Bitcoin);
                                                    }
                                                    else {
                                                        swapContext.setOrigCoin(CoinEnum.Stacks);
                                                    }
                                                }}>
                                                    <option value={CoinEnum.Bitcoin}>Bitcoin</option>
                                                    <option value={CoinEnum.Stacks}>Stacks</option>
                                                </Form.Select>
                                                <Form.Text className='text-right' muted>Price: {swapContext.getFormatedOrigPrice()}</Form.Text>
                                            </Form.Group>
                                        </Col>
                                        <Col md="6">
                                            <Form.Label htmlFor="origAmount">Amount:</Form.Label>
                                            <Form.Group as={Col}>
                                                <Form.Control
                                                    type="number"
                                                    step="0.1"
                                                    style={{ textAlign: 'right' }}
                                                    id="origAmount"
                                                    value={swapContext.origAmount}
                                                    onChange={(e) => {
                                                        swapContext.setOrigAmount(parseFloat(e.target.value));
                                                    }}
                                                />
                                                <Form.Text className='text-right' muted>Pool Balance {swapContext.getFormatedOrigBalance()}</Form.Text>
                                            </Form.Group>
                                        </Col>
                                    </Row>
                                </Card.Body>
                            </Card>
                            <Row className="mb-3">
                                <Col md="2" className='offset-md-5'>
                                    <view className='d-grid gap-2'>
                                        <Button size="lg" variant="warning" onClick={() => {
                                            if (swapContext.origCoin == CoinEnum.Bitcoin) {
                                                swapContext.setOrigCoin(CoinEnum.Stacks);
                                            }
                                            else {
                                                swapContext.setOrigCoin(CoinEnum.Bitcoin);
                                            }
                                        }}>
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
                                                <Form.Select value={swapContext.destCoin} onChange={(e) => {
                                                    if (e.target.value == '1') {
                                                        swapContext.setDestCoin(CoinEnum.Bitcoin);
                                                    }
                                                    else {
                                                        swapContext.setDestCoin(CoinEnum.Stacks);
                                                    }
                                                }}>
                                                    <option value={CoinEnum.Bitcoin}>Bitcoin</option>
                                                    <option value={CoinEnum.Stacks}>Stacks</option>
                                                </Form.Select>
                                                <Form.Text className='text-right' muted>Price: {swapContext.getFormatedDestPrice()}</Form.Text>
                                            </Form.Group>
                                        </Col>
                                        <Col md="6">
                                            <Form.Label htmlFor="destAmount">Amount:</Form.Label>
                                            <Form.Group as={Col}>
                                                <Form.Control
                                                    type="number"
                                                    step="0.1"
                                                    id="destAmount"
                                                    readOnly={true}
                                                    style={{ textAlign: 'right' }}
                                                    value={swapContext.destAmount}
                                                />
                                                <Form.Text className='text-right' muted>Pool Balance {swapContext.getFormatedDestBalance()}</Form.Text>
                                            </Form.Group>
                                        </Col>
                                    </Row>
                                </Card.Body>
                            </Card>
                            <p className="mb-3" style={{ textAlign: 'center' }}>{swapContext.getCoinText()}</p>
                            <Row>
                                <Col md="4" className='offset-md-4'>
                                    <view className='d-grid gap-2'>
                                        <Button size="lg" variant="primary">
                                            <FontAwesomeIcon icon={faRetweet} /> Swap
                                        </Button>
                                        <SwapModal></SwapModal>
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